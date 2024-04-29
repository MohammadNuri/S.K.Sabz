using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Common
{
	public class UploadDto
	{
		public long Id { get; set; }
		public bool Status { get; set; }
		public string FileNameAddress { get; set; } = string.Empty;
	}
}
