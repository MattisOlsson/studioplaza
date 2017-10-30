using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls.Adapters;
using N2.Web;
using StudioPlaza.Web.Templates.Configuration;
using Logica.Web.ImageTransforms;
using Logica.Web.WebControls;
using System.Drawing.Drawing2D;
	
namespace StudioPlaza.Web.Templates.Web.Adapters
{
	/// <summary>
	/// Adapts asp:image controls by changing their source to an image resizing handler that resizes the images on the server side.
	/// </summary>
	public class ImageAdapter : WebControlAdapter
	{
		static TransformedImageUrlBuilder ImageHandlerUrl = new TransformedImageUrlBuilder();

		static ImageAdapter()
		{
			TemplatesSection config = ConfigurationManager.GetSection("n2/templates") as TemplatesSection;
			if (config != null && !string.IsNullOrEmpty(config.ImageHandlerPath))
				ImageHandlerUrl.ImageHandlerUrl = config.ImageHandlerPath;
			else
				ImageHandlerUrl.ImageHandlerUrl = "/Img.ashx";
		}

		protected System.Web.UI.WebControls.Image ImageControl
		{
			get { return base.Control as System.Web.UI.WebControls.Image; }
		}

		protected override void Render(HtmlTextWriter writer)
		{
			if (!ImageControl.Height.IsEmpty || !ImageControl.Width.IsEmpty)
			{
				string thumbnailUrl = GetResizedImageUrl(ImageControl.ImageUrl, ImageControl.Width.Value, ImageControl.Height.Value, ImageResizeMode.Fit);

				writer.AddAttribute("alt", ImageControl.AlternateText);
				writer.AddAttribute("src", thumbnailUrl, false);
				writer.RenderBeginTag("img");
				writer.RenderEndTag();
			}
			else if (ImageControl.ImageUrl.Length > 0)
				base.Render(writer);
		}
		
		/// <summary>Returns the path to an image handler that resizes the given image to the appropriate size.</summary>
		/// <param name="imageUrl">The image to resize.</param>
		/// <param name="width">The maximum width.</param>
		/// <param name="height">The maximum height.</param>
		/// <returns>The path to a handler that performs resizing of the image.</returns>
		public static string GetResizedImageUrl(string imageUrl, double width, double height, ImageResizeMode resizeMode)
		{
			string fileExtension = VirtualPathUtility.GetExtension(Url.PathPart(imageUrl));
			bool isAlreadyImageHandler = string.Equals(fileExtension, ".ashx", StringComparison.OrdinalIgnoreCase);
			
			if (isAlreadyImageHandler) return Url.ToAbsolute(imageUrl);

			ImageHandlerUrl.ImageUrl = Url.ToAbsolute(imageUrl);
			if (width > 0)
				ImageHandlerUrl.Width = (int)width;
			if (height > 0)
				ImageHandlerUrl.Height = (int)height;

			ImageHandlerUrl.ResizeMode = resizeMode;
			ImageHandlerUrl.CompositingQuality = CompositingQuality.HighQuality;
			ImageHandlerUrl.InterpolationMode = InterpolationMode.HighQualityBilinear;
			return ImageHandlerUrl.ToString();
		}
	}
}
