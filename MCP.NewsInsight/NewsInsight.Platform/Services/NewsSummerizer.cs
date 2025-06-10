using System;
using System.Runtime.InteropServices;

namespace NewsInsight.Platform.Services
{
    public static class NewsSummarizer
    {
        [DllImport("NewsInsightAlgorithms.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Summarize(string text);

        public static string SummarizeNews(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return "(无内容)";

            IntPtr ptr = Summarize(content);
            return Marshal.PtrToStringAnsi(ptr);
        }
    }
}
