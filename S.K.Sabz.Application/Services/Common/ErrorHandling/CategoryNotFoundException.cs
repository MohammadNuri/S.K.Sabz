using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Application.Services.Common.ErrorHandling
{

	public class CategoryNotFoundException : Exception
	{
		public CategoryNotFoundException()
		{
		}

		public CategoryNotFoundException(string message)
			: base(message)
		{
		}

		public CategoryNotFoundException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}

}
