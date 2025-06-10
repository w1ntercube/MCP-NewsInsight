#pragma once
using namespace System;

namespace NewsInsight {
    namespace NativeWrapper {

        public ref class SummarizerBridge
        {
        public:
            static String^ Summarize(String^ input);
        };

    }
}
