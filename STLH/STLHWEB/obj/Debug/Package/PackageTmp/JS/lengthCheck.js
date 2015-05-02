function checklen(obj) {
         var lenE = obj.value.length;
         var lenC = 0;
         var CJK = obj.value.match(/[\u4E00-\u9FA5\uF900-\uFA2D]/g);
         if (CJK != null) lenC += CJK.length;
         var t;
         t= obj.maxlength - lenC - lenE;
         if (t < 0) {
             var tmp = 0
             var cut = obj.value.substring(0, obj.maxlength);
             for (var i = 0; i < cut.length; i++) {
                 tmp += /[\u4E00-\u9FA5\uF900-\uFA2D]/.test(cut.charAt(i)) ? 2 : 1;
                 if (tmp > obj.maxlength) break;
             }
             obj.value = cut.substring(0, i);
         }
     }
