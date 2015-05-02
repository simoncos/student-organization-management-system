using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLHCOMMON
{
    public class timeForm
    {
      public static  DateTime foreTimeToDb(string foreTime) {
            if (foreTime.Trim() == "")
            {
                foreTime= "1900-1-1 00:00:00";
            }
            DateTime time  = Convert.ToDateTime(foreTime.ToString().Trim());
            return time;
        }
      public static byte foreByteToDb(string foreByte) {
          if (foreByte.Trim() == "") {
              foreByte = "0";
          }
            byte ownByte=Convert.ToByte(foreByte.ToString().Trim());
          return ownByte;
        
        }

      public static int  foreIntToDb(string foreInt)
      {
          if (foreInt.Trim() == "")
          {
              foreInt = "0";
          }
          byte ownInt = Convert.ToByte(foreInt.ToString().Trim());
          return ownInt;

      }
      }
    }
