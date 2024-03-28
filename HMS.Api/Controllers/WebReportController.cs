using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WebReportController : ControllerBase
	{
		private readonly IWebHostEnvironment _webHost;
		private FastReport.Export.Image.ImageExport imgExp;
		private FastReport.Export.PdfSimple.PDFSimpleExport pdfExp;

		public WebReportController(IWebHostEnvironment webHost)
		{
			_webHost = webHost;
		}

		[HttpGet]
		//[Route("get")]
		public ActionResult<string?> Get()
		{
			try
			{
				WebReport webReport = new WebReport();

				webReport.Report.Load(_webHost.ContentRootPath + "\\Reports\\DoctorInfo.frx");

				MsSqlDataConnection sqlConnection = new MsSqlDataConnection();


				sqlConnection.ConnectionString = "server=(localdb)\\mssqllocaldb; database=HmsDb; Trusted_Connection=True;MultipleActiveResultSets=true;";


				webReport.Report.SetParameterValue("DbCon", sqlConnection.ConnectionString);


				webReport.Report.Prepare();


				PDFSimpleExport export = new PDFSimpleExport();
				string pdf;
				byte[] pdfBytes;
				MemoryStream ms = new MemoryStream();

				webReport.Report.Export(export, ms);
				ms.Position = 0;
				pdfBytes = ms.ToArray();

				pdf = Convert.ToBase64String(pdfBytes);
				return Ok(pdf);
			}
			catch (Exception ex)
			{

				return BadRequest(ex);
			}
		}

	}

}
