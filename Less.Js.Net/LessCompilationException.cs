using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ClearScript;

namespace Less.Js.Net
{
	public class LessCompilationException : Exception
	{
		internal LessCompilationException(ScriptEngineException e) : base(e.ErrorDetails, e)
		{
		}

	}
}
