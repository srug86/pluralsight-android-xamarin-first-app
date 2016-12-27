//using System;
//
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Net;
//using System.IO;
//using System.Text;
//
//namespace RaysHotDogs.Core
//{
//	public static class HttpWebRequestExtensions
//	{
//		public static Task<HttpWebResponse> GetResponseAsync(this HttpWebRequest request)
//		{
//			var tcs = new TaskCompletionSource<HttpWebResponse>();
//			 
//			try
//			{
//				request.BeginGetResponse(iar =>
//				{
//					try
//					{
//						var response = (HttpWebResponse)request.EndGetResponse(iar);
//						tcs.SetResult(response);
//					}
//					catch (Exception exc)
//					{
//						tcs.SetException(exc);
//					}
//				}, 
//				null);
//			}
//			catch (Exception exc)
//			{
//				tcs.SetException(exc);
//			}
//
//			return tcs.Task;
//		}
//	}
//}
//
//
//
