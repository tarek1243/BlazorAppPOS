using System;


namespace GeneralUtil
{
   public  class GeneralUtil
    {
        //Generate RandomNo
        public static int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        public static string replaceArabicNumbers(string in1)
        {

            string out1 = in1;
            out1 = out1.Replace("٠", "0");
            out1 = out1.Replace("٩", "9");
            out1 = out1.Replace("٨", "8");
            out1 = out1.Replace("٧", "7");
            out1 = out1.Replace("٦", "6");
            out1 = out1.Replace("٥", "5");
            out1 = out1.Replace("٤", "4");
            out1 = out1.Replace("٣", "3");
            out1 = out1.Replace("٢", "2");
            out1 = out1.Replace("١", "1");
            return out1;
        }
    }
}
