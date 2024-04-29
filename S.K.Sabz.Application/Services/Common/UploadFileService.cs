using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Common
{
	public class UploadFileService
	{
		private readonly string imageRootDirectory;

		public UploadFileService(string imageRootDirectory)
		{
			this.imageRootDirectory = imageRootDirectory;
		}

		public List<UploadDto> UploadFiles(List<IFormFile> files)
		{
			var uploadedResults = new List<UploadDto>();

			foreach (var file in files)
			{
				var uploadedResult = UploadFile(file);
				uploadedResults.Add(uploadedResult);
			}

			return uploadedResults;
		}

		public UploadDto UploadFile(IFormFile file)
		{
			string path = Path.Combine(Environment.CurrentDirectory, imageRootDirectory);

			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}

			if (file != null && file.Length > 0)
			{
				var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
				var filePath = Path.Combine(path, fileName);

				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					file.CopyTo(fileStream);
				}

				var relativePath = filePath.Replace(Environment.CurrentDirectory, string.Empty)
					.Replace("wwwroot/", string.Empty)
					.TrimStart(Path.DirectorySeparatorChar);

				return new UploadDto
				{
					FileNameAddress = relativePath,
					Status = true
				};
			}

			return new UploadDto
			{
				FileNameAddress = "",
				Status = false
			};
		}
	}
}
