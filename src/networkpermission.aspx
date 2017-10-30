<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Security.AccessControl" %>
<%@ Import Namespace="System.Security.Principal" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Runtime.InteropServices" %>

<script runat="server">

public const int LOGON32_LOGON_INTERACTIVE = 2;
public const int LOGON32_PROVIDER_DEFAULT = 0;

WindowsImpersonationContext impersonationContext; 

[DllImport("advapi32.dll")]
public static extern int LogonUserA(String lpszUserName, 
	String lpszDomain,
	String lpszPassword,
	int dwLogonType, 
	int dwLogonProvider,
	ref IntPtr phToken);
[DllImport("advapi32.dll", CharSet=CharSet.Auto, SetLastError=true)]
public static extern int DuplicateToken(IntPtr hToken, 
	int impersonationLevel,  
	ref IntPtr hNewToken);
                          
[DllImport("advapi32.dll", CharSet=CharSet.Auto, SetLastError=true)]
public static extern bool RevertToSelf();

[DllImport("kernel32.dll", CharSet=CharSet.Auto)]
public static extern  bool CloseHandle(IntPtr handle);		
		
protected void ChangeBT_Click(object sender, EventArgs e)
{
	string user = UserTB.Text;
	string pass = PassTB.Text;

	if(impersonateValidUser(user,"",pass))
	{
		// Get path from TextBox
		string path = PathTB.Text;
		string newuser = AccessDDL.Text;

		// The account which should be granted access
		NTAccount acc = new NTAccount(@newuser);

		// Rights which should be changed
		FileSystemRights rightName = FileSystemRights.Modify;
		AccessControlType right = AccessControlType.Allow;

		// Inherit to all subdirectories and files
		InheritanceFlags iFlags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;
		PropagationFlags pFlags = PropagationFlags.InheritOnly;

		// Get current filesecurity object
		DirectorySecurity security = Directory.GetAccessControl(path);

		// Create new rule
		FileSystemAccessRule rule = new FileSystemAccessRule(acc, rightName, iFlags, pFlags, right);

		// Add new rule to the security object
		security.AddAccessRule(rule);

		// Update file access control
		Directory.SetAccessControl(path, security);

		FailLB.Visible = false;
		SuccessLB.Visible = true;
		undoImpersonation();
	}
	else
	{
		SuccessLB.Visible = false;
		FailLB.Visible = true;
	}
}

private bool impersonateValidUser(String userName, String domain, String password)
{
	WindowsIdentity tempWindowsIdentity;
	IntPtr token = IntPtr.Zero;
	IntPtr tokenDuplicate = IntPtr.Zero;

	if(RevertToSelf())
	{
		if(LogonUserA(userName, domain, password, LOGON32_LOGON_INTERACTIVE, 
			LOGON32_PROVIDER_DEFAULT, ref token) != 0)
		{
			if(DuplicateToken(token, 2, ref tokenDuplicate) != 0) 
			{
				tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
				impersonationContext = tempWindowsIdentity.Impersonate();
				if (impersonationContext != null)
				{
					CloseHandle(token);
					CloseHandle(tokenDuplicate);
					return true;
				}
			}
		} 
	}
	if(token!= IntPtr.Zero)
		CloseHandle(token);
	if(tokenDuplicate!=IntPtr.Zero)
		CloseHandle(tokenDuplicate);
	return false;
}

private void undoImpersonation()
{
	impersonationContext.Undo();
}

</script>
 
<html>
<body>
        <form id="Form1" runat="server">
        <p>
                FTP Username:<br />
                <asp:TextBox ID="UserTB" runat="server" Width="250px" />
        </p>

        <p>
                FTP Password:<br />
                <asp:TextBox ID="PassTB" TextMode="password" runat="server" Width="250px" />
        </p>

        <p>
                Path: (d:\hshome\username\yourdomain\foldername)<br />
                <asp:TextBox ID="PathTB" runat="server" Width="350px" />
        </p>

        <p>
                Account to give access:<br />
                <asp:DropDownList ID="AccessDDL" runat="server" Width="350px">
			<asp:ListItem Text="NT AUTHORITY\NETWORK SERVICE" value="NT AUTHORITY\NETWORK SERVICE" selected="True" />
		</asp:DropDownList>
        </p>

        <p>
                <asp:Button ID="ChangeBT" runat="server" Text="Change Permissions" onclick="ChangeBT_Click" />
        </p>

        <p>
                <asp:Label ID="SuccessLB" runat="server" Text="Permissions changed!" Visible="False" />
		<asp:Label ID="FailLB" runat="server" Text="Failed to set permissions!" Visible="False" />
        </p>

        </form>
</body>
</html>