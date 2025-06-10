#include "SummarizerBridge.h"
#include "../NewsInsight.Algorithms/Summarizer.h"

using namespace System;
using namespace System::Runtime::InteropServices;

namespace NewsInsight {
    namespace NativeWrapper {

        String^ SummarizerBridge::Summarize(String^ input)
        {
            IntPtr ptrText = Marshal::StringToHGlobalAnsi(input);
            const char* result = ::Summarize((const char*)ptrText.ToPointer());
            String^ output = Marshal::PtrToStringAnsi(IntPtr((void*)result));
            Marshal::FreeHGlobal(ptrText);
            return output;
        }

    }
}
