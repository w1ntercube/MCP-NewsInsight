#include "Summarizer.h"
#include <string>

static std::string result;

const char* Summarize(const char* text)
{
    std::string input(text);
    result = "[DLL ժҪ]: " + input.substr(0, 100) + "...";
    return result.c_str();
}
