using System;
using System.Text.RegularExpressions;

namespace Form
{
    public static class Convert
    {
            public static Forms convertToText(Forms form)
            {

                if (form.Key == 'm')
                {
                    string conv1 = Regex.Replace(form.File, form.DateTime1, form.DateTime1Replace);
                    string conv2 = Regex.Replace(conv1, form.Unique1, form.Unique1Replace);
                    string conv3 = Regex.Replace(conv2, form.DateTime2, form.DateTime2Replace);
                    string conv = Regex.Replace(conv3, form.ClaimID, form.ClaimIDReplace);
                    string conv4 = Regex.Replace(conv, form.Unique2, form.Unique2Replace);

                    form.File = conv4;
                    return form;
                }

                if (form.Key == 'd')
                {
                    string conv1 = Regex.Replace(form.File, form.DateTime1, form.DateTime1Replace);
                    string conv2 = Regex.Replace(conv1, form.DateTime2, form.DateTime2Replace);
                    string conv3 = Regex.Replace(conv2, form.Unique1, form.Unique1Replace);
                    string conv = Regex.Replace(conv3, form.ClaimID, form.ClaimIDReplace);
                    string conv4 = Regex.Replace(conv, form.Unique2, form.Unique2Replace);

                    form.File = conv4;
                    return form;
                }
                else
                {
                    throw new Exception("Null Reference or unknown form passed to Form.Convert");
                }

            }
        
    }
}
