﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.Transforms;
using osu.Framework.IO.File;
using osu.Framework.IO.Stores;
using osu.Framework.Localisation;
using osu.Game.Database;
using osu.Game.IO;
using osu.Game.Skinning;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace osu.Game.Graphics.Sprites
{
    public class OsuSpriteTextTest : OsuSpriteText
    {

        public OsuSpriteTextTest()
        {
        }
        

        public bool test(ISkinSource skin)
        {
            for (int i = 0; i < 10; i++)
            {
                if (skin.GetTexture($"default-{i}") == null)
                    return false;
            }
            return true;
        }

        public static Stream GenerateStreamFromString()
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(@"info face=""Venera"" size=100 bold=1 italic=0 charset="""" unicode=1 stretchH=100 smooth=1 aa=4 padding=0,0,0,0 spacing=4,4 outline=0
common lineHeight = 100 base = 75 scaleW = 1024 scaleH = 1024 pages = 1 packed = 0 alphaChnl = 0 redChnl = 4 greenChnl = 4 blueChnl = 4
page id = 0 file = ""Venera_0.png""
chars count = 130
char id = 32   x = 1012  y = 0     width = 2     height = 1     xoffset = 0     yoffset = 99    xadvance = 31    page = 0  chnl = 15
char id = 33   x = 1008  y = 227   width = 12    height = 69    xoffset = 9     yoffset = 6     xadvance = 29    page = 0  chnl = 15
char id = 34   x = 37    y = 613   width = 33    height = 29    xoffset = 8     yoffset = 6     xadvance = 48    page = 0  chnl = 15
char id = 35   x = 348   y = 540   width = 69    height = 61    xoffset = 5     yoffset = 11    xadvance = 79    page = 0  chnl = 15
char id = 36   x = 0     y = 0     width = 86    height = 90    xoffset = 5     yoffset = 0     xadvance = 94    page = 0  chnl = 15
char id = 37   x = 534   y = 89    width = 99    height = 70    xoffset = 4     yoffset = 6     xadvance = 106   page = 0  chnl = 15
char id = 38   x = 278   y = 238   width = 88    height = 69    xoffset = 6     yoffset = 6     xadvance = 97    page = 0  chnl = 15
char id = 39   x = 991   y = 373   width = 11    height = 29    xoffset = 8     yoffset = 6     xadvance = 26    page = 0  chnl = 15
char id = 40   x = 344   y = 0     width = 21    height = 86    xoffset = 6     yoffset = 0     xadvance = 30    page = 0  chnl = 15
char id = 41   x = 369   y = 0     width = 21    height = 86    xoffset = 4     yoffset = 0     xadvance = 30    page = 0  chnl = 15
char id = 42   x = 843   y = 528   width = 44    height = 42    xoffset = 5     yoffset = 3     xadvance = 53    page = 0  chnl = 15
char id = 43   x = 421   y = 540   width = 62    height = 53    xoffset = 4     yoffset = 14    xadvance = 71    page = 0  chnl = 15
char id = 44   x = 991   y = 406   width = 19    height = 26    xoffset = 4     yoffset = 60    xadvance = 30    page = 0  chnl = 15
char id = 45   x = 655   y = 584   width = 38    height = 11    xoffset = 8     yoffset = 35    xadvance = 54    page = 0  chnl = 15
char id = 46   x = 410   y = 605   width = 12    height = 15    xoffset = 8     yoffset = 60    xadvance = 28    page = 0  chnl = 15
char id = 47   x = 90    y = 0     width = 49    height = 86    xoffset = 3     yoffset = 0     xadvance = 55    page = 0  chnl = 15
char id = 48   x = 99    y = 174   width = 91    height = 70    xoffset = 6     yoffset = 6     xadvance = 102   page = 0  chnl = 15
char id = 49   x = 981   y = 154   width = 32    height = 69    xoffset = 2     yoffset = 6     xadvance = 43    page = 0  chnl = 15
char id = 50   x = 341   y = 467   width = 80    height = 69    xoffset = 6     yoffset = 6     xadvance = 91    page = 0  chnl = 15
char id = 51   x = 508   y = 457   width = 78    height = 69    xoffset = 6     yoffset = 6     xadvance = 91    page = 0  chnl = 15
char id = 52   x = 886   y = 154   width = 91    height = 69    xoffset = 4     yoffset = 6     xadvance = 98    page = 0  chnl = 15
char id = 53   x = 874   y = 380   width = 82    height = 69    xoffset = 6     yoffset = 6     xadvance = 92    page = 0  chnl = 15
char id = 54   x = 631   y = 310   width = 85    height = 69    xoffset = 8     yoffset = 6     xadvance = 97    page = 0  chnl = 15
char id = 55   x = 425   y = 467   width = 79    height = 69    xoffset = 3     yoffset = 6     xadvance = 85    page = 0  chnl = 15
char id = 56   x = 529   y = 383   width = 83    height = 69    xoffset = 6     yoffset = 6     xadvance = 94    page = 0  chnl = 15
char id = 57   x = 720   y = 309   width = 85    height = 69    xoffset = 5     yoffset = 6     xadvance = 97    page = 0  chnl = 15
char id = 58   x = 975   y = 377   width = 12    height = 63    xoffset = 8     yoffset = 12    xadvance = 28    page = 0  chnl = 15
char id = 59   x = 989   y = 0     width = 19    height = 74    xoffset = 6     yoffset = 12    xadvance = 33    page = 0  chnl = 15
char id = 60   x = 536   y = 530   width = 45    height = 51    xoffset = 4     yoffset = 15    xadvance = 56    page = 0  chnl = 15
char id = 61   x = 891   y = 528   width = 62    height = 39    xoffset = 8     yoffset = 21    xadvance = 77    page = 0  chnl = 15
char id = 62   x = 487   y = 540   width = 45    height = 51    xoffset = 8     yoffset = 15    xadvance = 56    page = 0  chnl = 15
char id = 63   x = 136   y = 540   width = 62    height = 69    xoffset = 3     yoffset = 6     xadvance = 69    page = 0  chnl = 15
char id = 64   x = 620   y = 0     width = 94    height = 83    xoffset = 6     yoffset = 1     xadvance = 105   page = 0  chnl = 15
char id = 65   x = 592   y = 163   width = 96    height = 69    xoffset = 2     yoffset = 6     xadvance = 101   page = 0  chnl = 15
char id = 66   x = 362   y = 311   width = 86    height = 69    xoffset = 9     yoffset = 6     xadvance = 100   page = 0  chnl = 15
char id = 67   x = 91    y = 321   width = 87    height = 69    xoffset = 6     yoffset = 6     xadvance = 97    page = 0  chnl = 15
char id = 68   x = 186   y = 248   width = 88    height = 69    xoffset = 9     yoffset = 6     xadvance = 103   page = 0  chnl = 15
char id = 69   x = 917   y = 227   width = 87    height = 69    xoffset = 6     yoffset = 6     xadvance = 99    page = 0  chnl = 15
char id = 70   x = 702   y = 383   width = 82    height = 69    xoffset = 8     yoffset = 6     xadvance = 94    page = 0  chnl = 15
char id = 71   x = 0     y = 321   width = 87    height = 69    xoffset = 6     yoffset = 6     xadvance = 99    page = 0  chnl = 15
char id = 72   x = 353   y = 394   width = 84    height = 69    xoffset = 9     yoffset = 6     xadvance = 102   page = 0  chnl = 15
char id = 73   x = 1003  y = 300   width = 11    height = 69    xoffset = 9     yoffset = 6     xadvance = 29    page = 0  chnl = 15
char id = 74   x = 0     y = 540   width = 66    height = 69    xoffset = 2     yoffset = 6     xadvance = 76    page = 0  chnl = 15
char id = 75   x = 441   y = 384   width = 84    height = 69    xoffset = 9     yoffset = 6     xadvance = 93    page = 0  chnl = 15
char id = 76   x = 672   y = 456   width = 78    height = 69    xoffset = 8     yoffset = 6     xadvance = 88    page = 0  chnl = 15
char id = 77   x = 387   y = 164   width = 101   height = 69    xoffset = 9     yoffset = 6     xadvance = 119   page = 0  chnl = 15
char id = 78   x = 93    y = 248   width = 89    height = 69    xoffset = 9     yoffset = 6     xadvance = 107   page = 0  chnl = 15
char id = 79   x = 0     y = 174   width = 95    height = 70    xoffset = 6     yoffset = 6     xadvance = 106   page = 0  chnl = 15
char id = 80   x = 0     y = 394   width = 85    height = 69    xoffset = 9     yoffset = 6     xadvance = 97    page = 0  chnl = 15
char id = 81   x = 422   y = 0     width = 95    height = 85    xoffset = 6     yoffset = 6     xadvance = 106   page = 0  chnl = 15
char id = 82   x = 898   y = 304   width = 85    height = 69    xoffset = 9     yoffset = 6     xadvance = 100   page = 0  chnl = 15
char id = 83   x = 452   y = 310   width = 86    height = 69    xoffset = 5     yoffset = 6     xadvance = 95    page = 0  chnl = 15
char id = 84   x = 788   y = 382   width = 82    height = 69    xoffset = 1     yoffset = 6     xadvance = 85    page = 0  chnl = 15
char id = 85   x = 934   y = 80    width = 84    height = 70    xoffset = 8     yoffset = 6     xadvance = 100   page = 0  chnl = 15
char id = 86   x = 637   y = 87    width = 95    height = 70    xoffset = 3     yoffset = 6     xadvance = 99    page = 0  chnl = 15
char id = 87   x = 248   y = 90    width = 139   height = 70    xoffset = 3     yoffset = 6     xadvance = 144   page = 0  chnl = 15
char id = 88   x = 462   y = 237   width = 87    height = 69    xoffset = 1     yoffset = 6     xadvance = 89    page = 0  chnl = 15
char id = 89   x = 692   y = 161   width = 93    height = 69    xoffset = 0     yoffset = 6     xadvance = 94    page = 0  chnl = 15
char id = 90   x = 86    y = 467   width = 81    height = 69    xoffset = 5     yoffset = 6     xadvance = 91    page = 0  chnl = 15
char id = 91   x = 280   y = 0     width = 28    height = 86    xoffset = 9     yoffset = 0     xadvance = 41    page = 0  chnl = 15
char id = 92   x = 143   y = 0     width = 49    height = 86    xoffset = 3     yoffset = 0     xadvance = 55    page = 0  chnl = 15
char id = 93   x = 312   y = 0     width = 28    height = 86    xoffset = 5     yoffset = 0     xadvance = 41    page = 0  chnl = 15
char id = 94   x = 957   y = 526   width = 58    height = 37    xoffset = 4     yoffset = 2     xadvance = 66    page = 0  chnl = 15
char id = 95   x = 697   y = 583   width = 71    height = 10    xoffset = 8     yoffset = 82    xadvance = 86    page = 0  chnl = 15
char id = 96   x = 104   y = 164   width = 10    height = 1     xoffset = 28    yoffset = 0     xadvance = 50    page = 0  chnl = 15
char id = 97   x = 492   y = 164   width = 96    height = 69    xoffset = 2     yoffset = 6     xadvance = 101   page = 0  chnl = 15
char id = 98   x = 272   y = 321   width = 86    height = 69    xoffset = 9     yoffset = 6     xadvance = 100   page = 0  chnl = 15
char id = 99   x = 735   y = 234   width = 87    height = 69    xoffset = 6     yoffset = 6     xadvance = 97    page = 0  chnl = 15
char id = 100  x = 370   y = 237   width = 88    height = 69    xoffset = 9     yoffset = 6     xadvance = 103   page = 0  chnl = 15
char id = 101  x = 644   y = 236   width = 87    height = 69    xoffset = 6     yoffset = 6     xadvance = 99    page = 0  chnl = 15
char id = 102  x = 616   y = 383   width = 82    height = 69    xoffset = 8     yoffset = 6     xadvance = 94    page = 0  chnl = 15
char id = 103  x = 553   y = 237   width = 87    height = 69    xoffset = 6     yoffset = 6     xadvance = 99    page = 0  chnl = 15
char id = 104  x = 265   y = 394   width = 84    height = 69    xoffset = 9     yoffset = 6     xadvance = 102   page = 0  chnl = 15
char id = 105  x = 960   y = 377   width = 11    height = 69    xoffset = 9     yoffset = 6     xadvance = 29    page = 0  chnl = 15
char id = 106  x = 910   y = 453   width = 66    height = 69    xoffset = 2     yoffset = 6     xadvance = 76    page = 0  chnl = 15
char id = 107  x = 89    y = 394   width = 84    height = 69    xoffset = 9     yoffset = 6     xadvance = 93    page = 0  chnl = 15
char id = 108  x = 590   y = 456   width = 78    height = 69    xoffset = 8     yoffset = 6     xadvance = 88    page = 0  chnl = 15
char id = 109  x = 282   y = 164   width = 101   height = 69    xoffset = 9     yoffset = 6     xadvance = 119   page = 0  chnl = 15
char id = 110  x = 0     y = 248   width = 89    height = 69    xoffset = 9     yoffset = 6     xadvance = 107   page = 0  chnl = 15
char id = 111  x = 835   y = 80    width = 95    height = 70    xoffset = 6     yoffset = 6     xadvance = 106   page = 0  chnl = 15
char id = 112  x = 542   y = 310   width = 85    height = 69    xoffset = 9     yoffset = 6     xadvance = 97    page = 0  chnl = 15
char id = 113  x = 521   y = 0     width = 95    height = 85    xoffset = 6     yoffset = 6     xadvance = 106   page = 0  chnl = 15
char id = 114  x = 809   y = 307   width = 85    height = 69    xoffset = 9     yoffset = 6     xadvance = 100   page = 0  chnl = 15
char id = 115  x = 182   y = 321   width = 86    height = 69    xoffset = 5     yoffset = 6     xadvance = 95    page = 0  chnl = 15
char id = 116  x = 0     y = 467   width = 82    height = 69    xoffset = 1     yoffset = 6     xadvance = 85    page = 0  chnl = 15
char id = 117  x = 194   y = 164   width = 84    height = 70    xoffset = 8     yoffset = 6     xadvance = 100   page = 0  chnl = 15
char id = 118  x = 736   y = 84    width = 95    height = 70    xoffset = 3     yoffset = 6     xadvance = 99    page = 0  chnl = 15
char id = 119  x = 391   y = 90    width = 139   height = 70    xoffset = 3     yoffset = 6     xadvance = 144   page = 0  chnl = 15
char id = 120  x = 826   y = 231   width = 87    height = 69    xoffset = 1     yoffset = 6     xadvance = 89    page = 0  chnl = 15
char id = 121  x = 789   y = 158   width = 93    height = 69    xoffset = 0     yoffset = 6     xadvance = 94    page = 0  chnl = 15
char id = 122  x = 171   y = 467   width = 81    height = 69    xoffset = 5     yoffset = 6     xadvance = 91    page = 0  chnl = 15
char id = 123  x = 238   y = 0     width = 38    height = 86    xoffset = 3     yoffset = 0     xadvance = 45    page = 0  chnl = 15
char id = 124  x = 408   y = 0     width = 10    height = 86    xoffset = 9     yoffset = 0     xadvance = 27    page = 0  chnl = 15
char id = 125  x = 196   y = 0     width = 38    height = 86    xoffset = 5     yoffset = 0     xadvance = 45    page = 0  chnl = 15
char id = 126  x = 220   y = 608   width = 65    height = 21    xoffset = 7     yoffset = 30    xadvance = 79    page = 0  chnl = 15
char id = 161  x = 987   y = 300   width = 12    height = 69    xoffset = 9     yoffset = 6     xadvance = 29    page = 0  chnl = 15
char id = 162  x = 718   y = 0     width = 63    height = 80    xoffset = 4     yoffset = 3     xadvance = 73    page = 0  chnl = 15
char id = 163  x = 256   y = 467   width = 81    height = 69    xoffset = 5     yoffset = 6     xadvance = 89    page = 0  chnl = 15
char id = 164  x = 202   y = 540   width = 76    height = 64    xoffset = 6     yoffset = 9     xadvance = 87    page = 0  chnl = 15
char id = 165  x = 177   y = 394   width = 84    height = 69    xoffset = 3     yoffset = 6     xadvance = 90    page = 0  chnl = 15
char id = 166  x = 394   y = 0     width = 10    height = 86    xoffset = 9     yoffset = 0     xadvance = 27    page = 0  chnl = 15
char id = 167  x = 834   y = 455   width = 72    height = 69    xoffset = 5     yoffset = 6     xadvance = 82    page = 0  chnl = 15
char id = 168  x = 772   y = 583   width = 109   height = 1     xoffset = -23   yoffset = 99    xadvance = 61    page = 0  chnl = 15
char id = 169  x = 887   y = 0     width = 98    height = 76    xoffset = 5     yoffset = 3     xadvance = 109   page = 0  chnl = 15
char id = 171  x = 668   y = 529   width = 79    height = 50    xoffset = 3     yoffset = 16    xadvance = 90    page = 0  chnl = 15
char id = 173  x = 613   y = 584   width = 38    height = 11    xoffset = 8     yoffset = 35    xadvance = 54    page = 0  chnl = 15
char id = 174  x = 785   y = 0     width = 98    height = 76    xoffset = 5     yoffset = 3     xadvance = 109   page = 0  chnl = 15
char id = 176  x = 980   y = 444   width = 35    height = 35    xoffset = 6     yoffset = 4     xadvance = 46    page = 0  chnl = 15
char id = 177  x = 282   y = 540   width = 62    height = 63    xoffset = 7     yoffset = 12    xadvance = 76    page = 0  chnl = 15
char id = 180  x = 104   y = 169   width = 10    height = 1     xoffset = 14    yoffset = 0     xadvance = 54    page = 0  chnl = 15
char id = 182  x = 754   y = 456   width = 76    height = 69    xoffset = 4     yoffset = 6     xadvance = 88    page = 0  chnl = 15
char id = 183  x = 394   y = 605   width = 12    height = 15    xoffset = 8     yoffset = 31    xadvance = 28    page = 0  chnl = 15
char id = 184  x = 74    y = 613   width = 31    height = 29    xoffset = 6     yoffset = 71    xadvance = 44    page = 0  chnl = 15
char id = 187  x = 585   y = 530   width = 79    height = 50    xoffset = 8     yoffset = 16    xadvance = 90    page = 0  chnl = 15
char id = 191  x = 70    y = 540   width = 62    height = 69    xoffset = 4     yoffset = 6     xadvance = 69    page = 0  chnl = 15
char id = 8211 x = 541   y = 585   width = 68    height = 11    xoffset = 8     yoffset = 35    xadvance = 84    page = 0  chnl = 15
char id = 8212 x = 426   y = 597   width = 111   height = 11    xoffset = 8     yoffset = 35    xadvance = 126   page = 0  chnl = 15
char id = 8216 x = 1006  y = 373   width = 11    height = 29    xoffset = 8     yoffset = 6     xadvance = 26    page = 0  chnl = 15
char id = 8217 x = 109   y = 613   width = 11    height = 29    xoffset = 8     yoffset = 6     xadvance = 26    page = 0  chnl = 15
char id = 8218 x = 197   y = 613   width = 19    height = 26    xoffset = 4     yoffset = 60    xadvance = 30    page = 0  chnl = 15
char id = 8220 x = 980   y = 483   width = 33    height = 29    xoffset = 8     yoffset = 6     xadvance = 48    page = 0  chnl = 15
char id = 8221 x = 0     y = 613   width = 33    height = 29    xoffset = 8     yoffset = 6     xadvance = 48    page = 0  chnl = 15
char id = 8222 x = 124   y = 613   width = 40    height = 26    xoffset = 4     yoffset = 60    xadvance = 51    page = 0  chnl = 15
char id = 8224 x = 0     y = 94    width = 48    height = 76    xoffset = 3     yoffset = 6     xadvance = 55    page = 0  chnl = 15
char id = 8225 x = 52    y = 94    width = 48    height = 76    xoffset = 6     yoffset = 6     xadvance = 59    page = 0  chnl = 15
char id = 8226 x = 168   y = 613   width = 25    height = 26    xoffset = 9     yoffset = 28    xadvance = 42    page = 0  chnl = 15
char id = 8230 x = 289   y = 607   width = 101   height = 15    xoffset = 8     yoffset = 60    xadvance = 116   page = 0  chnl = 15
char id = 8240 x = 104   y = 90    width = 140   height = 70    xoffset = 4     yoffset = 6     xadvance = 147   page = 0  chnl = 15
char id = 8249 x = 751   y = 529   width = 42    height = 50    xoffset = 3     yoffset = 16    xadvance = 53    page = 0  chnl = 15
char id = 8250 x = 797   y = 529   width = 42    height = 50    xoffset = 8     yoffset = 16    xadvance = 53    page = 0  chnl = 15
kernings count = 1448
kerning first = 32  second = 65  amount = -4
kerning first = 32  second = 74  amount = -3
kerning first = 32  second = 84  amount = -3
kerning first = 32  second = 86  amount = -4
kerning first = 32  second = 87  amount = -3
kerning first = 32  second = 88  amount = -1
kerning first = 32  second = 89  amount = -4
kerning first = 32  second = 97  amount = -4
kerning first = 32  second = 106 amount = -3
kerning first = 32  second = 116 amount = -3
kerning first = 32  second = 118 amount = -4
kerning first = 32  second = 119 amount = -3
kerning first = 32  second = 120 amount = -1
kerning first = 32  second = 121 amount = -4
kerning first = 8250 second = 122 amount = -2
kerning first = 8250 second = 121 amount = -8
kerning first = 8250 second = 120 amount = -6
kerning first = 8250 second = 119 amount = -4
kerning first = 8250 second = 118 amount = -4
kerning first = 8250 second = 116 amount = -7
kerning first = 8250 second = 106 amount = -7
kerning first = 8250 second = 97  amount = -5
kerning first = 8250 second = 90  amount = -2
kerning first = 8250 second = 89  amount = -8
kerning first = 8250 second = 88  amount = -6
kerning first = 8250 second = 87  amount = -4
kerning first = 8250 second = 86  amount = -4
kerning first = 8250 second = 84  amount = -7
kerning first = 8250 second = 74  amount = -7
kerning first = 8250 second = 65  amount = -5
kerning first = 8249 second = 121 amount = -2
kerning first = 8249 second = 119 amount = -1
kerning first = 34  second = 44  amount = -10
kerning first = 34  second = 46  amount = -10
kerning first = 34  second = 47  amount = -5
kerning first = 34  second = 65  amount = -6
kerning first = 34  second = 74  amount = -11
kerning first = 34  second = 97  amount = -6
kerning first = 34  second = 106 amount = -11
kerning first = 8249 second = 118 amount = -1
kerning first = 8249 second = 97  amount = -1
kerning first = 8249 second = 89  amount = -2
kerning first = 8249 second = 87  amount = -1
kerning first = 8249 second = 86  amount = -1
kerning first = 8249 second = 65  amount = -1
kerning first = 8222 second = 8221 amount = -10
kerning first = 8222 second = 8220 amount = -10
kerning first = 8222 second = 8217 amount = -10
kerning first = 8222 second = 8216 amount = -10
kerning first = 8222 second = 121 amount = -11
kerning first = 8222 second = 119 amount = -7
kerning first = 8222 second = 118 amount = -8
kerning first = 8222 second = 116 amount = -9
kerning first = 34  second = 8218 amount = -10
kerning first = 34  second = 8222 amount = -10
kerning first = 34  second = 8230 amount = -10
kerning first = 38  second = 65  amount = -3
kerning first = 38  second = 74  amount = -2
kerning first = 38  second = 84  amount = -3
kerning first = 38  second = 86  amount = -3
kerning first = 38  second = 87  amount = -2
kerning first = 38  second = 88  amount = -2
kerning first = 38  second = 89  amount = -4
kerning first = 38  second = 90  amount = -1
kerning first = 38  second = 97  amount = -3
kerning first = 38  second = 106 amount = -2
kerning first = 38  second = 116 amount = -3
kerning first = 38  second = 118 amount = -3
kerning first = 38  second = 119 amount = -2
kerning first = 38  second = 120 amount = -2
kerning first = 38  second = 121 amount = -4
kerning first = 38  second = 122 amount = -1
kerning first = 8222 second = 89  amount = -11
kerning first = 8222 second = 87  amount = -7
kerning first = 8222 second = 86  amount = -8
kerning first = 8222 second = 84  amount = -9
kerning first = 8222 second = 55  amount = -7
kerning first = 8222 second = 52  amount = -3
kerning first = 8222 second = 49  amount = -4
kerning first = 8222 second = 39  amount = -10
kerning first = 8222 second = 34  amount = -10
kerning first = 8221 second = 8230 amount = -10
kerning first = 8221 second = 8222 amount = -10
kerning first = 8221 second = 8218 amount = -10
kerning first = 8221 second = 106 amount = -11
kerning first = 8221 second = 97  amount = -6
kerning first = 8221 second = 74  amount = -11
kerning first = 8221 second = 65  amount = -6
kerning first = 8221 second = 47  amount = -5
kerning first = 8221 second = 46  amount = -10
kerning first = 39  second = 44  amount = -10
kerning first = 39  second = 46  amount = -10
kerning first = 39  second = 47  amount = -5
kerning first = 39  second = 65  amount = -6
kerning first = 39  second = 74  amount = -11
kerning first = 39  second = 97  amount = -6
kerning first = 39  second = 106 amount = -11
kerning first = 8221 second = 44  amount = -10
kerning first = 8220 second = 8230 amount = -10
kerning first = 8220 second = 8222 amount = -10
kerning first = 8220 second = 8218 amount = -10
kerning first = 8220 second = 106 amount = -11
kerning first = 8220 second = 97  amount = -6
kerning first = 8220 second = 74  amount = -11
kerning first = 8220 second = 65  amount = -6
kerning first = 8220 second = 46  amount = -10
kerning first = 8220 second = 44  amount = -10
kerning first = 8218 second = 8221 amount = -10
kerning first = 8218 second = 8220 amount = -10
kerning first = 8218 second = 8217 amount = -10
kerning first = 8218 second = 8216 amount = -10
kerning first = 39  second = 8218 amount = -10
kerning first = 39  second = 8222 amount = -10
kerning first = 39  second = 8230 amount = -10
kerning first = 40  second = 48  amount = -2
kerning first = 40  second = 52  amount = -1
kerning first = 40  second = 54  amount = -1
kerning first = 40  second = 56  amount = -1
kerning first = 40  second = 67  amount = -1
kerning first = 40  second = 69  amount = -1
kerning first = 40  second = 71  amount = -1
kerning first = 40  second = 79  amount = -2
kerning first = 40  second = 81  amount = -2
kerning first = 40  second = 99  amount = -1
kerning first = 40  second = 101 amount = -1
kerning first = 40  second = 103 amount = -1
kerning first = 40  second = 111 amount = -2
kerning first = 40  second = 113 amount = -2
kerning first = 40  second = 123 amount = -1
kerning first = 8218 second = 121 amount = -11
kerning first = 8218 second = 119 amount = -7
kerning first = 8218 second = 118 amount = -8
kerning first = 8218 second = 116 amount = -9
kerning first = 8218 second = 89  amount = -11
kerning first = 8218 second = 87  amount = -7
kerning first = 8218 second = 86  amount = -8
kerning first = 8218 second = 84  amount = -9
kerning first = 8218 second = 55  amount = -7
kerning first = 8218 second = 52  amount = -3
kerning first = 8218 second = 49  amount = -4
kerning first = 8218 second = 39  amount = -10
kerning first = 8218 second = 34  amount = -10
kerning first = 8217 second = 8230 amount = -10
kerning first = 8217 second = 8222 amount = -10
kerning first = 8217 second = 8218 amount = -10
kerning first = 8217 second = 106 amount = -11
kerning first = 8217 second = 97  amount = -6
kerning first = 8217 second = 74  amount = -11
kerning first = 8217 second = 65  amount = -6
kerning first = 8217 second = 47  amount = -5
kerning first = 8217 second = 46  amount = -10
kerning first = 8217 second = 44  amount = -10
kerning first = 8216 second = 8230 amount = -10
kerning first = 8216 second = 8222 amount = -10
kerning first = 8216 second = 8218 amount = -10
kerning first = 8216 second = 106 amount = -11
kerning first = 8216 second = 97  amount = -6
kerning first = 42  second = 65  amount = -6
kerning first = 42  second = 74  amount = -11
kerning first = 42  second = 97  amount = -6
kerning first = 42  second = 106 amount = -11
kerning first = 8216 second = 74  amount = -11
kerning first = 8216 second = 65  amount = -6
kerning first = 8216 second = 46  amount = -10
kerning first = 8216 second = 44  amount = -10
kerning first = 8212 second = 122 amount = -3
kerning first = 8212 second = 121 amount = -7
kerning first = 8212 second = 120 amount = -6
kerning first = 8212 second = 119 amount = -4
kerning first = 8212 second = 118 amount = -4
kerning first = 8212 second = 116 amount = -8
kerning first = 8212 second = 106 amount = -9
kerning first = 8212 second = 97  amount = -4
kerning first = 8212 second = 90  amount = -3
kerning first = 8212 second = 89  amount = -7
kerning first = 43  second = 49  amount = -4
kerning first = 43  second = 50  amount = -2
kerning first = 43  second = 55  amount = -4
kerning first = 44  second = 34  amount = -10
kerning first = 44  second = 39  amount = -10
kerning first = 44  second = 49  amount = -4
kerning first = 44  second = 52  amount = -3
kerning first = 44  second = 55  amount = -7
kerning first = 44  second = 84  amount = -9
kerning first = 44  second = 86  amount = -8
kerning first = 44  second = 87  amount = -7
kerning first = 44  second = 89  amount = -11
kerning first = 44  second = 116 amount = -9
kerning first = 44  second = 118 amount = -8
kerning first = 44  second = 119 amount = -7
kerning first = 44  second = 121 amount = -11
kerning first = 8212 second = 88  amount = -6
kerning first = 8212 second = 87  amount = -4
kerning first = 8212 second = 86  amount = -4
kerning first = 8212 second = 84  amount = -8
kerning first = 44  second = 8216 amount = -10
kerning first = 44  second = 8217 amount = -10
kerning first = 44  second = 8220 amount = -10
kerning first = 44  second = 8221 amount = -10
kerning first = 45  second = 49  amount = -4
kerning first = 45  second = 50  amount = -3
kerning first = 45  second = 55  amount = -5
kerning first = 45  second = 65  amount = -4
kerning first = 45  second = 74  amount = -9
kerning first = 8212 second = 74  amount = -9
kerning first = 45  second = 84  amount = -8
kerning first = 45  second = 86  amount = -4
kerning first = 45  second = 87  amount = -4
kerning first = 45  second = 88  amount = -6
kerning first = 45  second = 89  amount = -7
kerning first = 45  second = 90  amount = -3
kerning first = 45  second = 97  amount = -4
kerning first = 45  second = 106 amount = -9
kerning first = 8212 second = 65  amount = -4
kerning first = 45  second = 116 amount = -8
kerning first = 45  second = 118 amount = -4
kerning first = 45  second = 119 amount = -4
kerning first = 45  second = 120 amount = -6
kerning first = 45  second = 121 amount = -7
kerning first = 45  second = 122 amount = -3
kerning first = 8212 second = 55  amount = -5
kerning first = 8212 second = 50  amount = -3
kerning first = 8212 second = 49  amount = -4
kerning first = 8211 second = 122 amount = -3
kerning first = 8211 second = 121 amount = -7
kerning first = 8211 second = 120 amount = -6
kerning first = 8211 second = 119 amount = -4
kerning first = 8211 second = 118 amount = -4
kerning first = 8211 second = 116 amount = -8
kerning first = 8211 second = 106 amount = -9
kerning first = 8211 second = 97  amount = -4
kerning first = 8211 second = 90  amount = -3
kerning first = 8211 second = 89  amount = -7
kerning first = 8211 second = 88  amount = -6
kerning first = 8211 second = 87  amount = -4
kerning first = 8211 second = 86  amount = -4
kerning first = 8211 second = 84  amount = -8
kerning first = 8211 second = 74  amount = -9
kerning first = 8211 second = 65  amount = -4
kerning first = 46  second = 34  amount = -10
kerning first = 46  second = 39  amount = -10
kerning first = 46  second = 49  amount = -4
kerning first = 46  second = 52  amount = -3
kerning first = 46  second = 55  amount = -7
kerning first = 46  second = 84  amount = -9
kerning first = 46  second = 86  amount = -8
kerning first = 46  second = 87  amount = -7
kerning first = 46  second = 89  amount = -11
kerning first = 46  second = 116 amount = -9
kerning first = 46  second = 118 amount = -8
kerning first = 46  second = 119 amount = -7
kerning first = 46  second = 121 amount = -11
kerning first = 8211 second = 55  amount = -5
kerning first = 8211 second = 50  amount = -3
kerning first = 8211 second = 49  amount = -4
kerning first = 191 second = 121 amount = -6
kerning first = 46  second = 8216 amount = -10
kerning first = 46  second = 8217 amount = -10
kerning first = 46  second = 8220 amount = -10
kerning first = 46  second = 8221 amount = -10
kerning first = 47  second = 47  amount = -9
kerning first = 47  second = 48  amount = -2
kerning first = 47  second = 54  amount = -1
kerning first = 47  second = 56  amount = -2
kerning first = 47  second = 65  amount = -9
kerning first = 47  second = 67  amount = -2
kerning first = 47  second = 69  amount = -2
kerning first = 47  second = 70  amount = -2
kerning first = 47  second = 71  amount = -2
kerning first = 47  second = 74  amount = -9
kerning first = 47  second = 79  amount = -2
kerning first = 47  second = 81  amount = -2
kerning first = 47  second = 83  amount = -1
kerning first = 47  second = 97  amount = -9
kerning first = 47  second = 99  amount = -2
kerning first = 47  second = 101 amount = -2
kerning first = 47  second = 102 amount = -2
kerning first = 47  second = 103 amount = -2
kerning first = 47  second = 106 amount = -9
kerning first = 47  second = 111 amount = -2
kerning first = 47  second = 113 amount = -2
kerning first = 47  second = 115 amount = -1
kerning first = 191 second = 119 amount = -6
kerning first = 191 second = 118 amount = -7
kerning first = 191 second = 117 amount = -1
kerning first = 191 second = 116 amount = -5
kerning first = 191 second = 113 amount = -1
kerning first = 191 second = 111 amount = -1
kerning first = 191 second = 89  amount = -6
kerning first = 191 second = 87  amount = -6
kerning first = 191 second = 86  amount = -7
kerning first = 191 second = 85  amount = -1
kerning first = 191 second = 84  amount = -5
kerning first = 191 second = 81  amount = -1
kerning first = 191 second = 79  amount = -1
kerning first = 187 second = 122 amount = -2
kerning first = 187 second = 121 amount = -8
kerning first = 187 second = 120 amount = -6
kerning first = 187 second = 119 amount = -4
kerning first = 187 second = 118 amount = -4
kerning first = 187 second = 116 amount = -7
kerning first = 187 second = 106 amount = -7
kerning first = 187 second = 97  amount = -5
kerning first = 187 second = 90  amount = -2
kerning first = 187 second = 89  amount = -8
kerning first = 187 second = 88  amount = -6
kerning first = 187 second = 87  amount = -4
kerning first = 187 second = 86  amount = -4
kerning first = 187 second = 84  amount = -7
kerning first = 187 second = 74  amount = -7
kerning first = 187 second = 65  amount = -5
kerning first = 183 second = 55  amount = -3
kerning first = 183 second = 50  amount = -2
kerning first = 183 second = 49  amount = -3
kerning first = 173 second = 122 amount = -3
kerning first = 173 second = 121 amount = -7
kerning first = 173 second = 120 amount = -6
kerning first = 173 second = 119 amount = -4
kerning first = 173 second = 118 amount = -4
kerning first = 173 second = 116 amount = -8
kerning first = 173 second = 106 amount = -9
kerning first = 173 second = 97  amount = -4
kerning first = 173 second = 90  amount = -3
kerning first = 173 second = 89  amount = -7
kerning first = 173 second = 88  amount = -6
kerning first = 48  second = 41  amount = -2
kerning first = 48  second = 47  amount = -3
kerning first = 48  second = 49  amount = -1
kerning first = 48  second = 55  amount = -1
kerning first = 48  second = 65  amount = -3
kerning first = 48  second = 86  amount = -3
kerning first = 48  second = 87  amount = -2
kerning first = 48  second = 88  amount = -2
kerning first = 48  second = 89  amount = -4
kerning first = 48  second = 92  amount = -2
kerning first = 48  second = 93  amount = -4
kerning first = 48  second = 97  amount = -3
kerning first = 48  second = 118 amount = -3
kerning first = 48  second = 119 amount = -2
kerning first = 48  second = 120 amount = -2
kerning first = 48  second = 121 amount = -4
kerning first = 48  second = 125 amount = -3
kerning first = 173 second = 87  amount = -4
kerning first = 173 second = 86  amount = -4
kerning first = 173 second = 84  amount = -8
kerning first = 173 second = 74  amount = -9
kerning first = 173 second = 65  amount = -4
kerning first = 173 second = 55  amount = -5
kerning first = 173 second = 50  amount = -3
kerning first = 173 second = 49  amount = -4
kerning first = 171 second = 121 amount = -2
kerning first = 171 second = 119 amount = -1
kerning first = 171 second = 118 amount = -1
kerning first = 171 second = 97  amount = -1
kerning first = 171 second = 89  amount = -2
kerning first = 171 second = 87  amount = -1
kerning first = 171 second = 86  amount = -1
kerning first = 171 second = 65  amount = -1
kerning first = 163 second = 52  amount = -2
kerning first = 163 second = 48  amount = -1
kerning first = 50  second = 45  amount = -1
kerning first = 50  second = 86  amount = -2
kerning first = 50  second = 87  amount = -1
kerning first = 50  second = 89  amount = -2
kerning first = 50  second = 92  amount = -1
kerning first = 50  second = 118 amount = -2
kerning first = 50  second = 119 amount = -1
kerning first = 50  second = 121 amount = -2
kerning first = 50  second = 173 amount = -1
kerning first = 125 second = 125 amount = -2
kerning first = 125 second = 93  amount = -2
kerning first = 125 second = 41  amount = -1
kerning first = 123 second = 123 amount = -2
kerning first = 50  second = 8211 amount = -1
kerning first = 50  second = 8212 amount = -1
kerning first = 123 second = 113 amount = -3
kerning first = 51  second = 41  amount = -1
kerning first = 51  second = 47  amount = -1
kerning first = 51  second = 65  amount = -2
kerning first = 51  second = 86  amount = -2
kerning first = 51  second = 87  amount = -2
kerning first = 51  second = 89  amount = -2
kerning first = 51  second = 92  amount = -1
kerning first = 51  second = 93  amount = -2
kerning first = 51  second = 97  amount = -2
kerning first = 51  second = 118 amount = -2
kerning first = 51  second = 119 amount = -2
kerning first = 51  second = 121 amount = -2
kerning first = 51  second = 125 amount = -2
kerning first = 123 second = 111 amount = -3
kerning first = 123 second = 103 amount = -3
kerning first = 123 second = 101 amount = -3
kerning first = 123 second = 99  amount = -3
kerning first = 123 second = 81  amount = -3
kerning first = 123 second = 79  amount = -3
kerning first = 123 second = 71  amount = -3
kerning first = 123 second = 69  amount = -3
kerning first = 123 second = 67  amount = -3
kerning first = 123 second = 56  amount = -2
kerning first = 123 second = 54  amount = -2
kerning first = 123 second = 52  amount = -2
kerning first = 123 second = 48  amount = -4
kerning first = 122 second = 8249 amount = -3
kerning first = 122 second = 8212 amount = -3
kerning first = 122 second = 8211 amount = -3
kerning first = 52  second = 41  amount = -1
kerning first = 52  second = 47  amount = -1
kerning first = 52  second = 49  amount = -2
kerning first = 52  second = 55  amount = -2
kerning first = 52  second = 65  amount = -2
kerning first = 52  second = 74  amount = -1
kerning first = 52  second = 84  amount = -2
kerning first = 52  second = 86  amount = -3
kerning first = 52  second = 87  amount = -3
kerning first = 52  second = 88  amount = -1
kerning first = 52  second = 89  amount = -3
kerning first = 52  second = 92  amount = -3
kerning first = 52  second = 93  amount = -2
kerning first = 52  second = 97  amount = -2
kerning first = 52  second = 106 amount = -1
kerning first = 52  second = 116 amount = -2
kerning first = 52  second = 118 amount = -3
kerning first = 52  second = 119 amount = -3
kerning first = 52  second = 120 amount = -1
kerning first = 52  second = 121 amount = -3
kerning first = 52  second = 125 amount = -2
kerning first = 52  second = 176 amount = -1
kerning first = 122 second = 173 amount = -3
kerning first = 122 second = 171 amount = -3
kerning first = 122 second = 113 amount = -1
kerning first = 122 second = 111 amount = -1
kerning first = 122 second = 81  amount = -1
kerning first = 122 second = 79  amount = -1
kerning first = 122 second = 45  amount = -3
kerning first = 121 second = 8250 amount = -2
kerning first = 121 second = 8249 amount = -8
kerning first = 121 second = 8230 amount = -11
kerning first = 121 second = 8222 amount = -11
kerning first = 121 second = 8218 amount = -11
kerning first = 121 second = 8212 amount = -7
kerning first = 121 second = 8211 amount = -7
kerning first = 121 second = 187 amount = -2
kerning first = 121 second = 174 amount = -3
kerning first = 121 second = 173 amount = -7
kerning first = 121 second = 171 amount = -8
kerning first = 53  second = 65  amount = -1
kerning first = 53  second = 86  amount = -1
kerning first = 53  second = 87  amount = -1
kerning first = 53  second = 97  amount = -1
kerning first = 53  second = 118 amount = -1
kerning first = 53  second = 119 amount = -1
kerning first = 121 second = 169 amount = -3
kerning first = 121 second = 115 amount = -2
kerning first = 121 second = 113 amount = -5
kerning first = 121 second = 111 amount = -5
kerning first = 121 second = 106 amount = -19
kerning first = 121 second = 103 amount = -5
kerning first = 121 second = 102 amount = -6
kerning first = 121 second = 101 amount = -4
kerning first = 121 second = 99  amount = -5
kerning first = 121 second = 97  amount = -14
kerning first = 121 second = 83  amount = -2
kerning first = 121 second = 81  amount = -5
kerning first = 54  second = 65  amount = -1
kerning first = 54  second = 86  amount = -2
kerning first = 54  second = 87  amount = -2
kerning first = 54  second = 89  amount = -1
kerning first = 54  second = 92  amount = -1
kerning first = 54  second = 93  amount = -1
kerning first = 54  second = 97  amount = -1
kerning first = 54  second = 118 amount = -2
kerning first = 54  second = 119 amount = -2
kerning first = 54  second = 121 amount = -1
kerning first = 54  second = 125 amount = -1
kerning first = 121 second = 79  amount = -5
kerning first = 121 second = 74  amount = -19
kerning first = 121 second = 71  amount = -5
kerning first = 121 second = 70  amount = -6
kerning first = 121 second = 69  amount = -4
kerning first = 121 second = 67  amount = -5
kerning first = 121 second = 65  amount = -14
kerning first = 121 second = 64  amount = -2
kerning first = 121 second = 57  amount = -1
kerning first = 121 second = 56  amount = -2
kerning first = 121 second = 54  amount = -2
kerning first = 121 second = 52  amount = -1
kerning first = 121 second = 48  amount = -4
kerning first = 121 second = 47  amount = -10
kerning first = 121 second = 46  amount = -11
kerning first = 121 second = 45  amount = -7
kerning first = 55  second = 44  amount = -8
kerning first = 55  second = 46  amount = -8
kerning first = 55  second = 47  amount = -7
kerning first = 55  second = 65  amount = -7
kerning first = 55  second = 74  amount = -12
kerning first = 55  second = 97  amount = -7
kerning first = 55  second = 106 amount = -12
kerning first = 121 second = 44  amount = -11
kerning first = 121 second = 38  amount = -2
kerning first = 121 second = 32  amount = -4
kerning first = 120 second = 8249 amount = -6
kerning first = 120 second = 8212 amount = -6
kerning first = 120 second = 8211 amount = -6
kerning first = 120 second = 174 amount = -1
kerning first = 120 second = 173 amount = -6
kerning first = 120 second = 171 amount = -6
kerning first = 120 second = 169 amount = -1
kerning first = 120 second = 113 amount = -4
kerning first = 120 second = 111 amount = -4
kerning first = 120 second = 103 amount = -4
kerning first = 120 second = 101 amount = -4
kerning first = 55  second = 8218 amount = -8
kerning first = 55  second = 8222 amount = -8
kerning first = 55  second = 8230 amount = -8
kerning first = 56  second = 41  amount = -1
kerning first = 56  second = 47  amount = -1
kerning first = 56  second = 65  amount = -2
kerning first = 56  second = 86  amount = -2
kerning first = 56  second = 87  amount = -2
kerning first = 56  second = 89  amount = -2
kerning first = 56  second = 92  amount = -1
kerning first = 56  second = 93  amount = -2
kerning first = 56  second = 97  amount = -2
kerning first = 56  second = 118 amount = -2
kerning first = 56  second = 119 amount = -2
kerning first = 56  second = 121 amount = -2
kerning first = 56  second = 125 amount = -2
kerning first = 120 second = 99  amount = -4
kerning first = 120 second = 81  amount = -4
kerning first = 120 second = 79  amount = -4
kerning first = 120 second = 71  amount = -4
kerning first = 120 second = 69  amount = -4
kerning first = 120 second = 67  amount = -4
kerning first = 120 second = 52  amount = -1
kerning first = 120 second = 48  amount = -2
kerning first = 120 second = 45  amount = -6
kerning first = 120 second = 32  amount = -1
kerning first = 119 second = 8250 amount = -1
kerning first = 119 second = 8249 amount = -4
kerning first = 119 second = 8230 amount = -7
kerning first = 119 second = 8222 amount = -7
kerning first = 119 second = 8218 amount = -7
kerning first = 119 second = 8212 amount = -4
kerning first = 57  second = 41  amount = -1
kerning first = 57  second = 47  amount = -2
kerning first = 57  second = 65  amount = -2
kerning first = 57  second = 86  amount = -2
kerning first = 57  second = 87  amount = -1
kerning first = 57  second = 89  amount = -2
kerning first = 57  second = 92  amount = -1
kerning first = 57  second = 93  amount = -2
kerning first = 57  second = 97  amount = -2
kerning first = 57  second = 118 amount = -2
kerning first = 57  second = 119 amount = -1
kerning first = 57  second = 121 amount = -2
kerning first = 57  second = 125 amount = -2
kerning first = 119 second = 8211 amount = -4
kerning first = 119 second = 187 amount = -1
kerning first = 119 second = 174 amount = -2
kerning first = 119 second = 173 amount = -4
kerning first = 119 second = 171 amount = -4
kerning first = 119 second = 169 amount = -2
kerning first = 119 second = 115 amount = -2
kerning first = 119 second = 113 amount = -3
kerning first = 119 second = 111 amount = -3
kerning first = 119 second = 106 amount = -13
kerning first = 119 second = 103 amount = -2
kerning first = 119 second = 102 amount = -3
kerning first = 119 second = 101 amount = -2
kerning first = 119 second = 99  amount = -2
kerning first = 119 second = 97  amount = -9
kerning first = 119 second = 83  amount = -2
kerning first = 119 second = 81  amount = -3
kerning first = 119 second = 79  amount = -3
kerning first = 64  second = 65  amount = -2
kerning first = 64  second = 86  amount = -2
kerning first = 64  second = 87  amount = -2
kerning first = 64  second = 89  amount = -2
kerning first = 64  second = 97  amount = -2
kerning first = 64  second = 118 amount = -2
kerning first = 64  second = 119 amount = -2
kerning first = 64  second = 121 amount = -2
kerning first = 119 second = 74  amount = -13
kerning first = 119 second = 71  amount = -2
kerning first = 119 second = 70  amount = -3
kerning first = 119 second = 69  amount = -2
kerning first = 119 second = 67  amount = -2
kerning first = 119 second = 65  amount = -9
kerning first = 119 second = 64  amount = -2
kerning first = 119 second = 57  amount = -1
kerning first = 119 second = 56  amount = -2
kerning first = 119 second = 54  amount = -2
kerning first = 119 second = 53  amount = -1
kerning first = 119 second = 52  amount = -1
kerning first = 119 second = 48  amount = -2
kerning first = 119 second = 47  amount = -8
kerning first = 119 second = 46  amount = -7
kerning first = 119 second = 45  amount = -4
kerning first = 119 second = 44  amount = -7
kerning first = 119 second = 38  amount = -2
kerning first = 65  second = 32  amount = -4
kerning first = 65  second = 34  amount = -6
kerning first = 65  second = 38  amount = -2
kerning first = 65  second = 39  amount = -6
kerning first = 65  second = 42  amount = -6
kerning first = 65  second = 45  amount = -4
kerning first = 65  second = 48  amount = -3
kerning first = 65  second = 49  amount = -7
kerning first = 65  second = 52  amount = -4
kerning first = 65  second = 54  amount = -2
kerning first = 65  second = 55  amount = -9
kerning first = 65  second = 56  amount = -2
kerning first = 65  second = 57  amount = -1
kerning first = 65  second = 63  amount = -6
kerning first = 65  second = 64  amount = -2
kerning first = 65  second = 67  amount = -3
kerning first = 65  second = 69  amount = -3
kerning first = 65  second = 71  amount = -3
kerning first = 65  second = 76  amount = -3
kerning first = 65  second = 79  amount = -3
kerning first = 65  second = 81  amount = -3
kerning first = 65  second = 84  amount = -10
kerning first = 65  second = 85  amount = -4
kerning first = 65  second = 86  amount = -10
kerning first = 65  second = 87  amount = -9
kerning first = 65  second = 89  amount = -14
kerning first = 65  second = 92  amount = -9
kerning first = 65  second = 99  amount = -3
kerning first = 65  second = 101 amount = -3
kerning first = 65  second = 103 amount = -3
kerning first = 65  second = 108 amount = -3
kerning first = 65  second = 111 amount = -3
kerning first = 65  second = 113 amount = -3
kerning first = 65  second = 116 amount = -10
kerning first = 65  second = 117 amount = -4
kerning first = 65  second = 118 amount = -10
kerning first = 65  second = 119 amount = -9
kerning first = 65  second = 121 amount = -14
kerning first = 65  second = 169 amount = -2
kerning first = 65  second = 171 amount = -5
kerning first = 65  second = 173 amount = -4
kerning first = 65  second = 174 amount = -2
kerning first = 65  second = 187 amount = -1
kerning first = 119 second = 32  amount = -3
kerning first = 118 second = 8250 amount = -1
kerning first = 118 second = 8249 amount = -4
kerning first = 118 second = 8230 amount = -8
kerning first = 118 second = 8222 amount = -8
kerning first = 118 second = 8218 amount = -8
kerning first = 118 second = 8212 amount = -4
kerning first = 118 second = 8211 amount = -4
kerning first = 118 second = 187 amount = -1
kerning first = 118 second = 174 amount = -2
kerning first = 118 second = 173 amount = -4
kerning first = 118 second = 171 amount = -4
kerning first = 118 second = 169 amount = -2
kerning first = 118 second = 115 amount = -2
kerning first = 118 second = 113 amount = -3
kerning first = 118 second = 111 amount = -3
kerning first = 118 second = 106 amount = -13
kerning first = 118 second = 103 amount = -3
kerning first = 118 second = 102 amount = -3
kerning first = 118 second = 101 amount = -3
kerning first = 118 second = 99  amount = -3
kerning first = 118 second = 97  amount = -10
kerning first = 118 second = 83  amount = -2
kerning first = 118 second = 81  amount = -3
kerning first = 118 second = 79  amount = -3
kerning first = 118 second = 74  amount = -13
kerning first = 118 second = 71  amount = -3
kerning first = 118 second = 70  amount = -3
kerning first = 118 second = 69  amount = -3
kerning first = 118 second = 67  amount = -3
kerning first = 118 second = 65  amount = -10
kerning first = 118 second = 64  amount = -2
kerning first = 118 second = 57  amount = -2
kerning first = 118 second = 56  amount = -2
kerning first = 118 second = 54  amount = -2
kerning first = 118 second = 53  amount = -1
kerning first = 118 second = 52  amount = -1
kerning first = 118 second = 48  amount = -3
kerning first = 65  second = 8211 amount = -4
kerning first = 65  second = 8212 amount = -4
kerning first = 65  second = 8216 amount = -6
kerning first = 65  second = 8217 amount = -6
kerning first = 65  second = 8220 amount = -6
kerning first = 65  second = 8221 amount = -6
kerning first = 65  second = 8249 amount = -5
kerning first = 65  second = 8250 amount = -1
kerning first = 118 second = 47  amount = -9
kerning first = 66  second = 41  amount = -1
kerning first = 66  second = 47  amount = -1
kerning first = 66  second = 65  amount = -2
kerning first = 118 second = 46  amount = -8
kerning first = 66  second = 86  amount = -2
kerning first = 66  second = 87  amount = -2
kerning first = 66  second = 88  amount = -1
kerning first = 66  second = 89  amount = -3
kerning first = 66  second = 92  amount = -1
kerning first = 66  second = 93  amount = -2
kerning first = 66  second = 97  amount = -2
kerning first = 118 second = 45  amount = -4
kerning first = 66  second = 118 amount = -2
kerning first = 66  second = 119 amount = -2
kerning first = 66  second = 120 amount = -1
kerning first = 66  second = 121 amount = -3
kerning first = 66  second = 125 amount = -2
kerning first = 118 second = 44  amount = -8
kerning first = 118 second = 38  amount = -2
kerning first = 118 second = 32  amount = -4
kerning first = 117 second = 106 amount = -2
kerning first = 117 second = 97  amount = -4
kerning first = 117 second = 74  amount = -2
kerning first = 117 second = 65  amount = -4
kerning first = 117 second = 47  amount = -3
kerning first = 116 second = 8249 amount = -7
kerning first = 116 second = 8230 amount = -9
kerning first = 116 second = 8222 amount = -9
kerning first = 116 second = 8218 amount = -9
kerning first = 116 second = 8212 amount = -8
kerning first = 116 second = 8211 amount = -8
kerning first = 116 second = 173 amount = -8
kerning first = 116 second = 171 amount = -7
kerning first = 116 second = 113 amount = -2
kerning first = 116 second = 111 amount = -2
kerning first = 67  second = 45  amount = -4
kerning first = 67  second = 67  amount = -1
kerning first = 67  second = 69  amount = -1
kerning first = 67  second = 71  amount = -1
kerning first = 67  second = 79  amount = -1
kerning first = 67  second = 81  amount = -1
kerning first = 67  second = 99  amount = -1
kerning first = 67  second = 101 amount = -1
kerning first = 67  second = 103 amount = -1
kerning first = 67  second = 111 amount = -1
kerning first = 67  second = 113 amount = -1
kerning first = 67  second = 171 amount = -3
kerning first = 67  second = 173 amount = -4
kerning first = 116 second = 106 amount = -17
kerning first = 116 second = 103 amount = -1
kerning first = 116 second = 102 amount = -2
kerning first = 116 second = 101 amount = -1
kerning first = 116 second = 99  amount = -1
kerning first = 116 second = 97  amount = -10
kerning first = 116 second = 81  amount = -2
kerning first = 116 second = 79  amount = -2
kerning first = 116 second = 74  amount = -17
kerning first = 116 second = 71  amount = -1
kerning first = 116 second = 70  amount = -2
kerning first = 116 second = 69  amount = -1
kerning first = 116 second = 67  amount = -1
kerning first = 116 second = 65  amount = -10
kerning first = 116 second = 47  amount = -9
kerning first = 116 second = 46  amount = -9
kerning first = 116 second = 45  amount = -8
kerning first = 116 second = 44  amount = -9
kerning first = 116 second = 32  amount = -3
kerning first = 115 second = 119 amount = -1
kerning first = 115 second = 118 amount = -1
kerning first = 115 second = 97  amount = -2
kerning first = 115 second = 87  amount = -1
kerning first = 115 second = 86  amount = -1
kerning first = 67  second = 8211 amount = -4
kerning first = 67  second = 8212 amount = -4
kerning first = 67  second = 8249 amount = -3
kerning first = 68  second = 41  amount = -1
kerning first = 68  second = 47  amount = -2
kerning first = 68  second = 65  amount = -3
kerning first = 68  second = 74  amount = -1
kerning first = 68  second = 84  amount = -1
kerning first = 68  second = 86  amount = -3
kerning first = 68  second = 87  amount = -2
kerning first = 68  second = 88  amount = -4
kerning first = 68  second = 89  amount = -5
kerning first = 115 second = 65  amount = -2
kerning first = 68  second = 92  amount = -2
kerning first = 68  second = 93  amount = -3
kerning first = 68  second = 97  amount = -3
kerning first = 68  second = 106 amount = -1
kerning first = 68  second = 116 amount = -1
kerning first = 68  second = 118 amount = -3
kerning first = 68  second = 119 amount = -2
kerning first = 68  second = 120 amount = -4
kerning first = 68  second = 121 amount = -5
kerning first = 114 second = 121 amount = -3
kerning first = 68  second = 125 amount = -3
kerning first = 114 second = 119 amount = -2
kerning first = 114 second = 118 amount = -2
kerning first = 114 second = 92  amount = -1
kerning first = 114 second = 89  amount = -3
kerning first = 114 second = 87  amount = -2
kerning first = 114 second = 86  amount = -2
kerning first = 113 second = 125 amount = -3
kerning first = 113 second = 121 amount = -5
kerning first = 113 second = 120 amount = -4
kerning first = 113 second = 119 amount = -3
kerning first = 113 second = 118 amount = -3
kerning first = 113 second = 116 amount = -2
kerning first = 113 second = 106 amount = -2
kerning first = 113 second = 97  amount = -3
kerning first = 113 second = 93  amount = -4
kerning first = 113 second = 92  amount = -2
kerning first = 113 second = 89  amount = -5
kerning first = 113 second = 88  amount = -4
kerning first = 113 second = 87  amount = -3
kerning first = 113 second = 86  amount = -3
kerning first = 113 second = 84  amount = -2
kerning first = 113 second = 74  amount = -2
kerning first = 113 second = 65  amount = -3
kerning first = 113 second = 63  amount = -1
kerning first = 113 second = 55  amount = -1
kerning first = 113 second = 49  amount = -1
kerning first = 113 second = 47  amount = -3
kerning first = 113 second = 41  amount = -2
kerning first = 112 second = 8230 amount = -7
kerning first = 112 second = 8222 amount = -7
kerning first = 112 second = 8218 amount = -7
kerning first = 112 second = 125 amount = -3
kerning first = 112 second = 122 amount = -1
kerning first = 112 second = 121 amount = -1
kerning first = 112 second = 120 amount = -4
kerning first = 112 second = 119 amount = -1
kerning first = 112 second = 118 amount = -1
kerning first = 112 second = 106 amount = -17
kerning first = 112 second = 97  amount = -6
kerning first = 112 second = 93  amount = -3
kerning first = 112 second = 90  amount = -1
kerning first = 112 second = 89  amount = -1
kerning first = 112 second = 88  amount = -4
kerning first = 112 second = 87  amount = -1
kerning first = 112 second = 86  amount = -1
kerning first = 112 second = 74  amount = -17
kerning first = 112 second = 65  amount = -6
kerning first = 112 second = 47  amount = -6
kerning first = 112 second = 46  amount = -7
kerning first = 112 second = 44  amount = -7
kerning first = 112 second = 41  amount = -1
kerning first = 112 second = 32  amount = -2
kerning first = 111 second = 125 amount = -3
kerning first = 70  second = 32  amount = -2
kerning first = 70  second = 44  amount = -4
kerning first = 70  second = 46  amount = -4
kerning first = 70  second = 47  amount = -4
kerning first = 70  second = 65  amount = -5
kerning first = 70  second = 74  amount = -18
kerning first = 111 second = 121 amount = -5
kerning first = 111 second = 120 amount = -4
kerning first = 70  second = 83  amount = -1
kerning first = 70  second = 97  amount = -5
kerning first = 70  second = 106 amount = -18
kerning first = 111 second = 119 amount = -3
kerning first = 111 second = 118 amount = -3
kerning first = 70  second = 115 amount = -1
kerning first = 111 second = 116 amount = -2
kerning first = 111 second = 106 amount = -2
kerning first = 111 second = 97  amount = -3
kerning first = 111 second = 93  amount = -4
kerning first = 111 second = 92  amount = -2
kerning first = 111 second = 89  amount = -5
kerning first = 111 second = 88  amount = -4
kerning first = 111 second = 87  amount = -3
kerning first = 111 second = 86  amount = -3
kerning first = 111 second = 84  amount = -2
kerning first = 111 second = 74  amount = -2
kerning first = 111 second = 65  amount = -3
kerning first = 111 second = 63  amount = -1
kerning first = 111 second = 55  amount = -1
kerning first = 111 second = 49  amount = -1
kerning first = 111 second = 47  amount = -3
kerning first = 111 second = 41  amount = -2
kerning first = 108 second = 8249 amount = -7
kerning first = 108 second = 8221 amount = -11
kerning first = 108 second = 8220 amount = -11
kerning first = 108 second = 8217 amount = -11
kerning first = 108 second = 8216 amount = -11
kerning first = 108 second = 8212 amount = -9
kerning first = 108 second = 8211 amount = -9
kerning first = 108 second = 183 amount = -9
kerning first = 108 second = 173 amount = -9
kerning first = 108 second = 171 amount = -7
kerning first = 108 second = 121 amount = -19
kerning first = 108 second = 119 amount = -14
kerning first = 70  second = 8218 amount = -4
kerning first = 70  second = 8222 amount = -4
kerning first = 70  second = 8230 amount = -4
kerning first = 71  second = 86  amount = -1
kerning first = 108 second = 118 amount = -16
kerning first = 71  second = 118 amount = -1
kerning first = 108 second = 117 amount = -2
kerning first = 74  second = 47  amount = -2
kerning first = 74  second = 65  amount = -3
kerning first = 74  second = 74  amount = -1
kerning first = 74  second = 97  amount = -3
kerning first = 74  second = 106 amount = -1
kerning first = 108 second = 116 amount = -19
kerning first = 108 second = 113 amount = -2
kerning first = 108 second = 111 amount = -2
kerning first = 108 second = 108 amount = -1
kerning first = 108 second = 103 amount = -1
kerning first = 108 second = 101 amount = -1
kerning first = 108 second = 99  amount = -1
kerning first = 108 second = 92  amount = -9
kerning first = 108 second = 89  amount = -19
kerning first = 108 second = 87  amount = -14
kerning first = 108 second = 86  amount = -16
kerning first = 108 second = 85  amount = -2
kerning first = 108 second = 84  amount = -19
kerning first = 108 second = 81  amount = -2
kerning first = 75  second = 32  amount = -1
kerning first = 75  second = 45  amount = -5
kerning first = 75  second = 48  amount = -1
kerning first = 75  second = 52  amount = -1
kerning first = 75  second = 67  amount = -3
kerning first = 75  second = 69  amount = -3
kerning first = 75  second = 71  amount = -3
kerning first = 75  second = 79  amount = -4
kerning first = 75  second = 81  amount = -4
kerning first = 75  second = 99  amount = -3
kerning first = 75  second = 101 amount = -3
kerning first = 75  second = 103 amount = -3
kerning first = 75  second = 111 amount = -4
kerning first = 75  second = 113 amount = -4
kerning first = 75  second = 169 amount = -1
kerning first = 75  second = 171 amount = -5
kerning first = 75  second = 173 amount = -5
kerning first = 75  second = 174 amount = -1
kerning first = 108 second = 79  amount = -2
kerning first = 108 second = 76  amount = -1
kerning first = 108 second = 71  amount = -1
kerning first = 108 second = 69  amount = -1
kerning first = 108 second = 67  amount = -1
kerning first = 108 second = 63  amount = -5
kerning first = 108 second = 55  amount = -9
kerning first = 108 second = 52  amount = -7
kerning first = 108 second = 49  amount = -6
kerning first = 108 second = 45  amount = -9
kerning first = 108 second = 42  amount = -11
kerning first = 108 second = 39  amount = -11
kerning first = 108 second = 34  amount = -11
kerning first = 108 second = 32  amount = -3
kerning first = 107 second = 8249 amount = -5
kerning first = 107 second = 8212 amount = -5
kerning first = 107 second = 8211 amount = -5
kerning first = 107 second = 174 amount = -1
kerning first = 107 second = 173 amount = -5
kerning first = 107 second = 171 amount = -5
kerning first = 107 second = 169 amount = -1
kerning first = 107 second = 113 amount = -4
kerning first = 107 second = 111 amount = -4
kerning first = 107 second = 103 amount = -3
kerning first = 75  second = 8211 amount = -5
kerning first = 75  second = 8212 amount = -5
kerning first = 75  second = 8249 amount = -5
kerning first = 76  second = 32  amount = -3
kerning first = 76  second = 34  amount = -11
kerning first = 76  second = 39  amount = -11
kerning first = 76  second = 42  amount = -11
kerning first = 76  second = 45  amount = -9
kerning first = 76  second = 49  amount = -6
kerning first = 76  second = 52  amount = -7
kerning first = 76  second = 55  amount = -9
kerning first = 76  second = 63  amount = -5
kerning first = 76  second = 67  amount = -1
kerning first = 76  second = 69  amount = -1
kerning first = 76  second = 71  amount = -1
kerning first = 76  second = 76  amount = -1
kerning first = 76  second = 79  amount = -2
kerning first = 76  second = 81  amount = -2
kerning first = 76  second = 84  amount = -19
kerning first = 76  second = 85  amount = -2
kerning first = 76  second = 86  amount = -16
kerning first = 76  second = 87  amount = -14
kerning first = 76  second = 89  amount = -19
kerning first = 76  second = 92  amount = -9
kerning first = 76  second = 99  amount = -1
kerning first = 76  second = 101 amount = -1
kerning first = 76  second = 103 amount = -1
kerning first = 76  second = 108 amount = -1
kerning first = 76  second = 111 amount = -2
kerning first = 76  second = 113 amount = -2
kerning first = 76  second = 116 amount = -19
kerning first = 76  second = 117 amount = -2
kerning first = 76  second = 118 amount = -16
kerning first = 76  second = 119 amount = -14
kerning first = 76  second = 121 amount = -19
kerning first = 76  second = 171 amount = -7
kerning first = 76  second = 173 amount = -9
kerning first = 76  second = 183 amount = -9
kerning first = 107 second = 101 amount = -3
kerning first = 107 second = 99  amount = -3
kerning first = 107 second = 81  amount = -4
kerning first = 107 second = 79  amount = -4
kerning first = 107 second = 71  amount = -3
kerning first = 107 second = 69  amount = -3
kerning first = 107 second = 67  amount = -3
kerning first = 107 second = 52  amount = -1
kerning first = 107 second = 48  amount = -1
kerning first = 107 second = 45  amount = -5
kerning first = 107 second = 32  amount = -1
kerning first = 106 second = 106 amount = -1
kerning first = 106 second = 97  amount = -3
kerning first = 106 second = 74  amount = -1
kerning first = 106 second = 65  amount = -3
kerning first = 106 second = 47  amount = -2
kerning first = 103 second = 118 amount = -1
kerning first = 103 second = 86  amount = -1
kerning first = 102 second = 8230 amount = -4
kerning first = 102 second = 8222 amount = -4
kerning first = 102 second = 8218 amount = -4
kerning first = 102 second = 115 amount = -1
kerning first = 102 second = 106 amount = -18
kerning first = 102 second = 97  amount = -5
kerning first = 102 second = 83  amount = -1
kerning first = 102 second = 74  amount = -18
kerning first = 102 second = 65  amount = -5
kerning first = 102 second = 47  amount = -4
kerning first = 102 second = 46  amount = -4
kerning first = 102 second = 44  amount = -4
kerning first = 102 second = 32  amount = -2
kerning first = 100 second = 125 amount = -3
kerning first = 100 second = 121 amount = -5
kerning first = 100 second = 120 amount = -4
kerning first = 100 second = 119 amount = -2
kerning first = 100 second = 118 amount = -3
kerning first = 76  second = 8211 amount = -9
kerning first = 76  second = 8212 amount = -9
kerning first = 76  second = 8216 amount = -11
kerning first = 76  second = 8217 amount = -11
kerning first = 76  second = 8220 amount = -11
kerning first = 76  second = 8221 amount = -11
kerning first = 76  second = 8249 amount = -7
kerning first = 100 second = 116 amount = -1
kerning first = 79  second = 41  amount = -2
kerning first = 79  second = 47  amount = -3
kerning first = 79  second = 49  amount = -1
kerning first = 79  second = 55  amount = -1
kerning first = 79  second = 63  amount = -1
kerning first = 79  second = 65  amount = -3
kerning first = 79  second = 74  amount = -2
kerning first = 79  second = 84  amount = -2
kerning first = 79  second = 86  amount = -3
kerning first = 79  second = 87  amount = -3
kerning first = 79  second = 88  amount = -4
kerning first = 79  second = 89  amount = -5
kerning first = 100 second = 106 amount = -1
kerning first = 79  second = 92  amount = -2
kerning first = 79  second = 93  amount = -4
kerning first = 79  second = 97  amount = -3
kerning first = 79  second = 106 amount = -2
kerning first = 79  second = 116 amount = -2
kerning first = 79  second = 118 amount = -3
kerning first = 79  second = 119 amount = -3
kerning first = 79  second = 120 amount = -4
kerning first = 79  second = 121 amount = -5
kerning first = 100 second = 97  amount = -3
kerning first = 79  second = 125 amount = -3
kerning first = 100 second = 93  amount = -3
kerning first = 100 second = 92  amount = -2
kerning first = 100 second = 89  amount = -5
kerning first = 100 second = 88  amount = -4
kerning first = 100 second = 87  amount = -2
kerning first = 100 second = 86  amount = -3
kerning first = 100 second = 84  amount = -1
kerning first = 100 second = 74  amount = -1
kerning first = 100 second = 65  amount = -3
kerning first = 100 second = 47  amount = -2
kerning first = 100 second = 41  amount = -1
kerning first = 99  second = 8249 amount = -3
kerning first = 99  second = 8212 amount = -4
kerning first = 99  second = 8211 amount = -4
kerning first = 99  second = 173 amount = -4
kerning first = 99  second = 171 amount = -3
kerning first = 99  second = 113 amount = -1
kerning first = 99  second = 111 amount = -1
kerning first = 99  second = 103 amount = -1
kerning first = 80  second = 32  amount = -2
kerning first = 80  second = 41  amount = -1
kerning first = 80  second = 44  amount = -7
kerning first = 80  second = 46  amount = -7
kerning first = 80  second = 47  amount = -6
kerning first = 80  second = 65  amount = -6
kerning first = 80  second = 74  amount = -17
kerning first = 80  second = 86  amount = -1
kerning first = 80  second = 87  amount = -1
kerning first = 80  second = 88  amount = -4
kerning first = 80  second = 89  amount = -1
kerning first = 80  second = 90  amount = -1
kerning first = 80  second = 93  amount = -3
kerning first = 80  second = 97  amount = -6
kerning first = 80  second = 106 amount = -17
kerning first = 80  second = 118 amount = -1
kerning first = 80  second = 119 amount = -1
kerning first = 80  second = 120 amount = -4
kerning first = 80  second = 121 amount = -1
kerning first = 80  second = 122 amount = -1
kerning first = 80  second = 125 amount = -3
kerning first = 99  second = 101 amount = -1
kerning first = 99  second = 99  amount = -1
kerning first = 99  second = 81  amount = -1
kerning first = 99  second = 79  amount = -1
kerning first = 99  second = 71  amount = -1
kerning first = 99  second = 69  amount = -1
kerning first = 99  second = 67  amount = -1
kerning first = 99  second = 45  amount = -4
kerning first = 98  second = 125 amount = -2
kerning first = 98  second = 121 amount = -3
kerning first = 98  second = 120 amount = -1
kerning first = 98  second = 119 amount = -2
kerning first = 98  second = 118 amount = -2
kerning first = 98  second = 97  amount = -2
kerning first = 98  second = 93  amount = -2
kerning first = 98  second = 92  amount = -1
kerning first = 98  second = 89  amount = -3
kerning first = 98  second = 88  amount = -1
kerning first = 80  second = 8218 amount = -7
kerning first = 80  second = 8222 amount = -7
kerning first = 80  second = 8230 amount = -7
kerning first = 81  second = 41  amount = -2
kerning first = 81  second = 47  amount = -3
kerning first = 81  second = 49  amount = -1
kerning first = 81  second = 55  amount = -1
kerning first = 81  second = 63  amount = -1
kerning first = 81  second = 65  amount = -3
kerning first = 81  second = 74  amount = -2
kerning first = 81  second = 84  amount = -2
kerning first = 81  second = 86  amount = -3
kerning first = 81  second = 87  amount = -3
kerning first = 81  second = 88  amount = -4
kerning first = 81  second = 89  amount = -5
kerning first = 98  second = 87  amount = -2
kerning first = 81  second = 92  amount = -2
kerning first = 81  second = 93  amount = -4
kerning first = 81  second = 97  amount = -3
kerning first = 81  second = 106 amount = -2
kerning first = 81  second = 116 amount = -2
kerning first = 81  second = 118 amount = -3
kerning first = 81  second = 119 amount = -3
kerning first = 81  second = 120 amount = -4
kerning first = 81  second = 121 amount = -5
kerning first = 98  second = 86  amount = -2
kerning first = 81  second = 125 amount = -3
kerning first = 98  second = 65  amount = -2
kerning first = 98  second = 47  amount = -1
kerning first = 98  second = 41  amount = -1
kerning first = 97  second = 8250 amount = -1
kerning first = 97  second = 8249 amount = -5
kerning first = 97  second = 8221 amount = -6
kerning first = 97  second = 8220 amount = -6
kerning first = 97  second = 8217 amount = -6
kerning first = 97  second = 8216 amount = -6
kerning first = 97  second = 8212 amount = -4
kerning first = 97  second = 8211 amount = -4
kerning first = 97  second = 187 amount = -1
kerning first = 97  second = 174 amount = -2
kerning first = 97  second = 173 amount = -4
kerning first = 97  second = 171 amount = -5
kerning first = 97  second = 169 amount = -2
kerning first = 97  second = 121 amount = -14
kerning first = 97  second = 119 amount = -9
kerning first = 97  second = 118 amount = -10
kerning first = 82  second = 86  amount = -2
kerning first = 82  second = 87  amount = -2
kerning first = 82  second = 89  amount = -3
kerning first = 82  second = 92  amount = -1
kerning first = 82  second = 118 amount = -2
kerning first = 82  second = 119 amount = -2
kerning first = 82  second = 121 amount = -3
kerning first = 97  second = 117 amount = -4
kerning first = 97  second = 116 amount = -10
kerning first = 97  second = 113 amount = -3
kerning first = 97  second = 111 amount = -3
kerning first = 83  second = 65  amount = -2
kerning first = 97  second = 108 amount = -3
kerning first = 83  second = 86  amount = -1
kerning first = 83  second = 87  amount = -1
kerning first = 97  second = 103 amount = -3
kerning first = 83  second = 97  amount = -2
kerning first = 97  second = 101 amount = -3
kerning first = 83  second = 118 amount = -1
kerning first = 83  second = 119 amount = -1
kerning first = 97  second = 99  amount = -3
kerning first = 97  second = 92  amount = -9
kerning first = 97  second = 89  amount = -14
kerning first = 97  second = 87  amount = -9
kerning first = 97  second = 86  amount = -10
kerning first = 97  second = 85  amount = -4
kerning first = 97  second = 84  amount = -10
kerning first = 97  second = 81  amount = -3
kerning first = 97  second = 79  amount = -3
kerning first = 97  second = 76  amount = -3
kerning first = 97  second = 71  amount = -3
kerning first = 97  second = 69  amount = -3
kerning first = 97  second = 67  amount = -3
kerning first = 97  second = 64  amount = -2
kerning first = 97  second = 63  amount = -6
kerning first = 97  second = 57  amount = -1
kerning first = 97  second = 56  amount = -2
kerning first = 84  second = 32  amount = -3
kerning first = 84  second = 44  amount = -9
kerning first = 84  second = 45  amount = -8
kerning first = 84  second = 46  amount = -9
kerning first = 84  second = 47  amount = -9
kerning first = 84  second = 65  amount = -10
kerning first = 84  second = 67  amount = -1
kerning first = 84  second = 69  amount = -1
kerning first = 84  second = 70  amount = -2
kerning first = 84  second = 71  amount = -1
kerning first = 84  second = 74  amount = -17
kerning first = 84  second = 79  amount = -2
kerning first = 84  second = 81  amount = -2
kerning first = 84  second = 97  amount = -10
kerning first = 84  second = 99  amount = -1
kerning first = 84  second = 101 amount = -1
kerning first = 84  second = 102 amount = -2
kerning first = 84  second = 103 amount = -1
kerning first = 84  second = 106 amount = -17
kerning first = 84  second = 111 amount = -2
kerning first = 84  second = 113 amount = -2
kerning first = 84  second = 171 amount = -7
kerning first = 84  second = 173 amount = -8
kerning first = 97  second = 55  amount = -9
kerning first = 97  second = 54  amount = -2
kerning first = 97  second = 52  amount = -4
kerning first = 97  second = 49  amount = -7
kerning first = 97  second = 48  amount = -3
kerning first = 97  second = 45  amount = -4
kerning first = 97  second = 42  amount = -6
kerning first = 97  second = 39  amount = -6
kerning first = 97  second = 38  amount = -2
kerning first = 97  second = 34  amount = -6
kerning first = 97  second = 32  amount = -4
kerning first = 92  second = 8221 amount = -5
kerning first = 92  second = 8217 amount = -5
kerning first = 92  second = 121 amount = -10
kerning first = 92  second = 119 amount = -8
kerning first = 92  second = 118 amount = -9
kerning first = 92  second = 117 amount = -3
kerning first = 92  second = 116 amount = -9
kerning first = 92  second = 113 amount = -3
kerning first = 92  second = 111 amount = -3
kerning first = 92  second = 108 amount = -2
kerning first = 92  second = 103 amount = -2
kerning first = 92  second = 101 amount = -2
kerning first = 92  second = 99  amount = -2
kerning first = 92  second = 89  amount = -10
kerning first = 92  second = 87  amount = -8
kerning first = 92  second = 86  amount = -9
kerning first = 92  second = 85  amount = -3
kerning first = 92  second = 84  amount = -9
kerning first = 92  second = 81  amount = -3
kerning first = 92  second = 79  amount = -3
kerning first = 92  second = 76  amount = -2
kerning first = 92  second = 71  amount = -2
kerning first = 92  second = 69  amount = -2
kerning first = 92  second = 67  amount = -2
kerning first = 92  second = 56  amount = -1
kerning first = 92  second = 55  amount = -8
kerning first = 92  second = 54  amount = -2
kerning first = 84  second = 8211 amount = -8
kerning first = 84  second = 8212 amount = -8
kerning first = 84  second = 8218 amount = -9
kerning first = 84  second = 8222 amount = -9
kerning first = 84  second = 8230 amount = -9
kerning first = 84  second = 8249 amount = -7
kerning first = 85  second = 47  amount = -3
kerning first = 85  second = 65  amount = -4
kerning first = 85  second = 74  amount = -2
kerning first = 85  second = 97  amount = -4
kerning first = 85  second = 106 amount = -2
kerning first = 92  second = 52  amount = -4
kerning first = 92  second = 49  amount = -6
kerning first = 92  second = 48  amount = -3
kerning first = 92  second = 39  amount = -5
kerning first = 92  second = 34  amount = -5
kerning first = 91  second = 123 amount = -2
kerning first = 91  second = 113 amount = -4
kerning first = 91  second = 111 amount = -4
kerning first = 91  second = 103 amount = -3
kerning first = 91  second = 101 amount = -3
kerning first = 91  second = 99  amount = -3
kerning first = 91  second = 81  amount = -4
kerning first = 91  second = 79  amount = -4
kerning first = 91  second = 71  amount = -3
kerning first = 86  second = 32  amount = -4
kerning first = 86  second = 38  amount = -2
kerning first = 86  second = 44  amount = -8
kerning first = 86  second = 45  amount = -4
kerning first = 86  second = 46  amount = -8
kerning first = 86  second = 47  amount = -9
kerning first = 86  second = 48  amount = -3
kerning first = 86  second = 52  amount = -1
kerning first = 86  second = 53  amount = -1
kerning first = 86  second = 54  amount = -2
kerning first = 86  second = 56  amount = -2
kerning first = 86  second = 57  amount = -2
kerning first = 86  second = 64  amount = -2
kerning first = 86  second = 65  amount = -10
kerning first = 86  second = 67  amount = -3
kerning first = 86  second = 69  amount = -3
kerning first = 86  second = 70  amount = -3
kerning first = 86  second = 71  amount = -3
kerning first = 86  second = 74  amount = -13
kerning first = 86  second = 79  amount = -3
kerning first = 86  second = 81  amount = -3
kerning first = 86  second = 83  amount = -2
kerning first = 86  second = 97  amount = -10
kerning first = 86  second = 99  amount = -3
kerning first = 86  second = 101 amount = -3
kerning first = 86  second = 102 amount = -3
kerning first = 86  second = 103 amount = -3
kerning first = 86  second = 106 amount = -13
kerning first = 86  second = 111 amount = -3
kerning first = 86  second = 113 amount = -3
kerning first = 86  second = 115 amount = -2
kerning first = 86  second = 169 amount = -2
kerning first = 86  second = 171 amount = -4
kerning first = 86  second = 173 amount = -4
kerning first = 86  second = 174 amount = -2
kerning first = 86  second = 187 amount = -1
kerning first = 91  second = 69  amount = -3
kerning first = 91  second = 67  amount = -3
kerning first = 91  second = 56  amount = -2
kerning first = 91  second = 54  amount = -2
kerning first = 91  second = 52  amount = -2
kerning first = 91  second = 48  amount = -4
kerning first = 90  second = 8249 amount = -3
kerning first = 90  second = 8212 amount = -3
kerning first = 90  second = 8211 amount = -3
kerning first = 90  second = 173 amount = -3
kerning first = 90  second = 171 amount = -3
kerning first = 90  second = 113 amount = -1
kerning first = 90  second = 111 amount = -1
kerning first = 90  second = 81  amount = -1
kerning first = 90  second = 79  amount = -1
kerning first = 90  second = 45  amount = -3
kerning first = 89  second = 8250 amount = -2
kerning first = 89  second = 8249 amount = -8
kerning first = 89  second = 8230 amount = -11
kerning first = 89  second = 8222 amount = -11
kerning first = 89  second = 8218 amount = -11
kerning first = 89  second = 8212 amount = -7
kerning first = 89  second = 8211 amount = -7
kerning first = 89  second = 187 amount = -2
kerning first = 89  second = 174 amount = -3
kerning first = 89  second = 173 amount = -7
kerning first = 89  second = 171 amount = -8
kerning first = 89  second = 169 amount = -3
kerning first = 89  second = 115 amount = -2
kerning first = 89  second = 113 amount = -5
kerning first = 89  second = 111 amount = -5
kerning first = 89  second = 106 amount = -19
kerning first = 89  second = 103 amount = -5
kerning first = 89  second = 102 amount = -6
kerning first = 89  second = 101 amount = -4
kerning first = 89  second = 99  amount = -5
kerning first = 89  second = 97  amount = -14
kerning first = 89  second = 83  amount = -2
kerning first = 89  second = 81  amount = -5
kerning first = 89  second = 79  amount = -5
kerning first = 89  second = 74  amount = -19
kerning first = 86  second = 8211 amount = -4
kerning first = 86  second = 8212 amount = -4
kerning first = 86  second = 8218 amount = -8
kerning first = 86  second = 8222 amount = -8
kerning first = 86  second = 8230 amount = -8
kerning first = 86  second = 8249 amount = -4
kerning first = 86  second = 8250 amount = -1
kerning first = 87  second = 32  amount = -3
kerning first = 87  second = 38  amount = -2
kerning first = 87  second = 44  amount = -7
kerning first = 87  second = 45  amount = -4
kerning first = 87  second = 46  amount = -7
kerning first = 87  second = 47  amount = -8
kerning first = 87  second = 48  amount = -2
kerning first = 87  second = 52  amount = -1
kerning first = 87  second = 53  amount = -1
kerning first = 87  second = 54  amount = -2
kerning first = 87  second = 56  amount = -2
kerning first = 87  second = 57  amount = -1
kerning first = 87  second = 64  amount = -2
kerning first = 87  second = 65  amount = -9
kerning first = 87  second = 67  amount = -2
kerning first = 87  second = 69  amount = -2
kerning first = 87  second = 70  amount = -3
kerning first = 87  second = 71  amount = -2
kerning first = 87  second = 74  amount = -13
kerning first = 87  second = 79  amount = -3
kerning first = 87  second = 81  amount = -3
kerning first = 87  second = 83  amount = -2
kerning first = 87  second = 97  amount = -9
kerning first = 87  second = 99  amount = -2
kerning first = 87  second = 101 amount = -2
kerning first = 87  second = 102 amount = -3
kerning first = 87  second = 103 amount = -2
kerning first = 87  second = 106 amount = -13
kerning first = 87  second = 111 amount = -3
kerning first = 87  second = 113 amount = -3
kerning first = 87  second = 115 amount = -2
kerning first = 87  second = 169 amount = -2
kerning first = 87  second = 171 amount = -4
kerning first = 87  second = 173 amount = -4
kerning first = 87  second = 174 amount = -2
kerning first = 87  second = 187 amount = -1
kerning first = 89  second = 71  amount = -5
kerning first = 89  second = 70  amount = -6
kerning first = 89  second = 69  amount = -4
kerning first = 89  second = 67  amount = -5
kerning first = 89  second = 65  amount = -14
kerning first = 89  second = 64  amount = -2
kerning first = 89  second = 57  amount = -1
kerning first = 89  second = 56  amount = -2
kerning first = 89  second = 54  amount = -2
kerning first = 89  second = 52  amount = -1
kerning first = 89  second = 48  amount = -4
kerning first = 89  second = 47  amount = -10
kerning first = 89  second = 46  amount = -11
kerning first = 89  second = 45  amount = -7
kerning first = 89  second = 44  amount = -11
kerning first = 89  second = 38  amount = -2
kerning first = 89  second = 32  amount = -4
kerning first = 88  second = 8249 amount = -6
kerning first = 88  second = 8212 amount = -6
kerning first = 88  second = 8211 amount = -6
kerning first = 88  second = 174 amount = -1
kerning first = 88  second = 173 amount = -6
kerning first = 88  second = 171 amount = -6
kerning first = 88  second = 169 amount = -1
kerning first = 88  second = 113 amount = -4
kerning first = 88  second = 111 amount = -4
kerning first = 88  second = 103 amount = -4
kerning first = 88  second = 101 amount = -4
kerning first = 88  second = 99  amount = -4
kerning first = 88  second = 81  amount = -4
kerning first = 88  second = 79  amount = -4
kerning first = 88  second = 71  amount = -4
kerning first = 88  second = 69  amount = -4
kerning first = 88  second = 67  amount = -4
kerning first = 88  second = 52  amount = -1
kerning first = 88  second = 48  amount = -2
kerning first = 88  second = 45  amount = -6
kerning first = 88  second = 32  amount = -1
kerning first = 87  second = 8250 amount = -1
kerning first = 87  second = 8249 amount = -4
kerning first = 87  second = 8230 amount = -7
kerning first = 87  second = 8211 amount = -4
kerning first = 87  second = 8212 amount = -4
kerning first = 87  second = 8218 amount = -7
kerning first = 87  second = 8222 amount = -7
");
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        [BackgroundDependencyLoader]
        private void load(ISkinSource source, FileStore FileStore, SkinManager skinManager, FontStore fontStore)
        {
            Stream streamFont = GenerateStreamFromString();
            Stream[] streamPng = new Stream[10];

            SkinInfo skinInfo = skinManager.CurrentSkinInfo.Value;
            IResourceStore<byte[]> storage = FileStore.Store;
            LegacySkinResourceStore<SkinFileInfo> legacySkinResourceStore = new LegacySkinResourceStore<SkinFileInfo>(skinInfo, storage);
            for (int i = 0; i<10; i++)
                streamPng[i] = legacySkinResourceStore.GetStream($"default-{i}.png");

            StreamRessourceStore streamRessourceStore = new StreamRessourceStore(streamFont, streamPng);
            ResourceStore<byte[]> resourceStore = new ResourceStore<byte[]>(streamRessourceStore);
            GlyphStore glyphStore = new GlyphStore(resourceStore, @"defaultNum");
            fontStore.AddStore(glyphStore);
            //fontStore.RemoveStore(glyphStore);
        }
        protected class LegacySkinResourceStore<T> : IResourceStore<byte[]>
            where T : INamedFileInfo
        {
            private readonly IHasFiles<T> source;
            private readonly IResourceStore<byte[]> underlyingStore;

            private string getPathForFile(string filename)
            {
                bool hasExtension = filename.Contains('.');

                string lastPiece = filename.Split('/').Last();

                var file = source.Files.FirstOrDefault(f =>
                    string.Equals(hasExtension ? f.Filename : Path.ChangeExtension(f.Filename, null), lastPiece, StringComparison.InvariantCultureIgnoreCase));
                return file?.FileInfo.StoragePath;
            }

            public LegacySkinResourceStore(IHasFiles<T> source, IResourceStore<byte[]> underlyingStore)
            {
                this.source = source;
                this.underlyingStore = underlyingStore;
            }

            public Stream GetStream(string name)
            {
                string path = getPathForFile(name);
                return path == null ? null : underlyingStore.GetStream(path);
            }

            byte[] IResourceStore<byte[]>.Get(string name) => GetAsync(name).Result;

            public Task<byte[]> GetAsync(string name)
            {
                string path = getPathForFile(name);
                return path == null ? Task.FromResult<byte[]>(null) : underlyingStore.GetAsync(path);
            }

            #region IDisposable Support

            private bool isDisposed;

            protected virtual void Dispose(bool disposing)
            {
                if (!isDisposed)
                {
                    isDisposed = true;
                }
            }

            ~LegacySkinResourceStore()
            {
                Dispose(false);
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            #endregion
        }
    }
}
