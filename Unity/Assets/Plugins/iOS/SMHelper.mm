extern "C"
{
    char* SixMinuteMakeStringCopy(NSString* nstring)
    {
        const char* string = [nstring UTF8String];
        if (string == NULL)
        {
            return NULL;
        }
        char* res = (char*)malloc(strlen(string) + 1);
        strcpy(res, string);
        return res;
    }
    
    const char* SixMinuteVersion()
    {
        return SixMinuteMakeStringCopy([[NSBundle mainBundle] objectForInfoDictionaryKey: @"CFBundleShortVersionString"]);
    }
    
    const char* SixMinuteBuild()
    {
        return SixMinuteMakeStringCopy([[NSBundle mainBundle] objectForInfoDictionaryKey:(NSString *)kCFBundleVersionKey]);
    }
}