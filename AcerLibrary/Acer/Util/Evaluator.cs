using System;
using System.CodeDom.Compiler;
using System.Reflection;

namespace Acer.Util
{
	/// <summary>
	/// 執行 Eval 指令方法
	/// </summary>
	public class Evaluator
	{
		/// <summary>
		/// 計算結果,如果表達式出錯則拋出異常
		/// </summary>
		/// <param name="statement">表達式,如"1+2+3+4"</param>
		/// <returns>結果</returns>
		public static object Eval(string statement)
		{
			return	_evaluatorType.InvokeMember
				(
					"Eval",
					BindingFlags.InvokeMethod,
					null,
					_evaluator,
					new object[] { statement }
				);
		}

		static Evaluator()
		{
			//=== 構造JScript的編譯驅動代碼 ===
			CodeDomProvider		provider	=	CodeDomProvider.CreateProvider("JScript");

			CompilerParameters	parameters	=	 new CompilerParameters();
			parameters.GenerateInMemory	=	true;

			CompilerResults		results		=	provider.CompileAssemblyFromSource(parameters, _jscriptSource);
			Assembly		assembly	=	results.CompiledAssembly;
			_evaluatorType	=	assembly.GetType("Evaluator");

			_evaluator	=	Activator.CreateInstance(_evaluatorType);
		}

		private static	object _evaluator	=	null;
		private static	Type	_evaluatorType	=	null;

		private static	readonly string _jscriptSource	=	@"class Evaluator
									{
										public function Eval(expr : String) : String 
										{
											return eval(expr); 
										}
									}";
	}
}
