using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Davang.Utilities.Helpers
{
    public static class Colors
    {
        private static readonly Color m_Transparent = Color.FromArgb(0, 255, 255, 255);
        private static readonly Color m_AliceBlue = Color.FromArgb(255,240, 248, 255);
        private static readonly Color m_AntiqueWhite = Color.FromArgb(255,250, 235, 215);
        private static readonly Color m_Aqua = Color.FromArgb(255,0, 255, 255);
        private static readonly Color m_Aquamarine = Color.FromArgb(255,127, 255, 212);
        private static readonly Color m_Azure = Color.FromArgb(255,240, 255, 255);
        private static readonly Color m_Beige = Color.FromArgb(255,245, 245, 220);
        private static readonly Color m_Bisque = Color.FromArgb(255,255, 228, 196);
        private static readonly Color m_Black = Color.FromArgb(255,0, 0, 0);
        private static readonly Color m_BlanchedAlmond = Color.FromArgb(255,255, 235, 205);
        private static readonly Color m_Blue = Color.FromArgb(255,0, 0, 255);
        private static readonly Color m_BlueViolet = Color.FromArgb(255,138, 43, 226);
        private static readonly Color m_Brown = Color.FromArgb(255,165, 42, 42);
        private static readonly Color m_BurlyWood = Color.FromArgb(255,222, 184, 135);
        private static readonly Color m_CadetBlue = Color.FromArgb(255,95, 158, 160);
        private static readonly Color m_Chartreuse = Color.FromArgb(255,127, 255, 0);
        private static readonly Color m_Chocolate = Color.FromArgb(255,210, 105, 30);
        private static readonly Color m_Coral = Color.FromArgb(255,255, 127, 80);
        private static readonly Color m_CornflowerBlue = Color.FromArgb(255,100, 149, 237);
        private static readonly Color m_Cornsilk = Color.FromArgb(255,255, 248, 220);
        private static readonly Color m_Crimson = Color.FromArgb(255,220, 20, 60);
        private static readonly Color m_Cyan = Color.FromArgb(255,0, 255, 255);
        private static readonly Color m_DarkBlue = Color.FromArgb(255,0, 0, 139);
        private static readonly Color m_DarkCyan = Color.FromArgb(255,0, 139, 139);
        private static readonly Color m_DarkGoldenrod = Color.FromArgb(255,184, 134, 11);
        private static readonly Color m_DarkGray = Color.FromArgb(255,169, 169, 169);
        private static readonly Color m_DarkGreen = Color.FromArgb(255,0, 100, 0);
        private static readonly Color m_DarkKhaki = Color.FromArgb(255,189, 183, 107);
        private static readonly Color m_DarkMagenta = Color.FromArgb(255,139, 0, 139);
        private static readonly Color m_DarkOliveGreen = Color.FromArgb(255,85, 107, 47);
        private static readonly Color m_DarkOrange = Color.FromArgb(255,255, 140, 0);
        private static readonly Color m_DarkOrchid = Color.FromArgb(255,153, 50, 204);
        private static readonly Color m_DarkRed = Color.FromArgb(255,139, 0, 0);
        private static readonly Color m_DarkSalmon = Color.FromArgb(255,233, 150, 122);
        private static readonly Color m_DarkSeaGreen = Color.FromArgb(255,143, 188, 139);
        private static readonly Color m_DarkSlateBlue = Color.FromArgb(255,72, 61, 139);
        private static readonly Color m_DarkSlateGray = Color.FromArgb(255,47, 79, 79);
        private static readonly Color m_DarkTurquoise = Color.FromArgb(255,0, 206, 209);
        private static readonly Color m_DarkViolet = Color.FromArgb(255,148, 0, 211);
        private static readonly Color m_DeepPink = Color.FromArgb(255,255, 20, 147);
        private static readonly Color m_DeepSkyBlue = Color.FromArgb(255,0, 191, 255);
        private static readonly Color m_DimGray = Color.FromArgb(255,105, 105, 105);
        private static readonly Color m_DodgerBlue = Color.FromArgb(255,30, 144, 255);
        private static readonly Color m_Firebrick = Color.FromArgb(255,178, 34, 34);
        private static readonly Color m_FloralWhite = Color.FromArgb(255,255, 250, 240);
        private static readonly Color m_ForestGreen = Color.FromArgb(255,34, 139, 34);
        private static readonly Color m_Fuchsia = Color.FromArgb(255,255, 0, 255);
        private static readonly Color m_Gainsboro = Color.FromArgb(255,220, 220, 220);
        private static readonly Color m_GhostWhite = Color.FromArgb(255,248, 248, 255);
        private static readonly Color m_Gold = Color.FromArgb(255,255, 215, 0);
        private static readonly Color m_Goldenrod = Color.FromArgb(255,218, 165, 32);
        private static readonly Color m_Gray = Color.FromArgb(255,128, 128, 128);
        private static readonly Color m_Green = Color.FromArgb(255,0, 128, 0);
        private static readonly Color m_GreenYellow = Color.FromArgb(255,173, 255, 47);
        private static readonly Color m_Honeydew = Color.FromArgb(255,240, 255, 240);
        private static readonly Color m_HotPink = Color.FromArgb(255,255, 105, 180);
        private static readonly Color m_IndianRed = Color.FromArgb(255,205, 92, 92);
        private static readonly Color m_Indigo = Color.FromArgb(255,75, 0, 130);
        private static readonly Color m_Ivory = Color.FromArgb(255,255, 255, 240);
        private static readonly Color m_Khaki = Color.FromArgb(255,240, 230, 140);
        private static readonly Color m_Lavender = Color.FromArgb(255,230, 230, 250);
        private static readonly Color m_LavenderBlush = Color.FromArgb(255,255, 240, 245);
        private static readonly Color m_LawnGreen = Color.FromArgb(255,124, 252, 0);
        private static readonly Color m_LemonChiffon = Color.FromArgb(255,255, 250, 205);
        private static readonly Color m_LightBlue = Color.FromArgb(255,173, 216, 230);
        private static readonly Color m_LightCoral = Color.FromArgb(255,240, 128, 128);
        private static readonly Color m_LightCyan = Color.FromArgb(255,224, 255, 255);
        private static readonly Color m_LightGoldenrodYellow = Color.FromArgb(255,250, 250, 210);
        private static readonly Color m_LightGreen = Color.FromArgb(255,144, 238, 144);
        private static readonly Color m_LightGray = Color.FromArgb(255,211, 211, 211);
        private static readonly Color m_LightPink = Color.FromArgb(255,255, 182, 193);
        private static readonly Color m_LightSalmon = Color.FromArgb(255,255, 160, 122);
        private static readonly Color m_LightSeaGreen = Color.FromArgb(255,32, 178, 170);
        private static readonly Color m_LightSkyBlue = Color.FromArgb(255,135, 206, 250);
        private static readonly Color m_LightSlateGray = Color.FromArgb(255,119, 136, 153);
        private static readonly Color m_LightSteelBlue = Color.FromArgb(255,176, 196, 222);
        private static readonly Color m_LightYellow = Color.FromArgb(255,255, 255, 224);
        private static readonly Color m_Lime = Color.FromArgb(255,0, 255, 0);
        private static readonly Color m_LimeGreen = Color.FromArgb(255,50, 205, 50);
        private static readonly Color m_Linen = Color.FromArgb(255,250, 240, 230);
        private static readonly Color m_Magenta = Color.FromArgb(255,255, 0, 255);
        private static readonly Color m_Maroon = Color.FromArgb(255,128, 0, 0);
        private static readonly Color m_MediumAquamarine = Color.FromArgb(255,102, 205, 170);
        private static readonly Color m_MediumBlue = Color.FromArgb(255,0, 0, 205);
        private static readonly Color m_MediumOrchid = Color.FromArgb(255,186, 85, 211);
        private static readonly Color m_MediumPurple = Color.FromArgb(255,147, 112, 219);
        private static readonly Color m_MediumSeaGreen = Color.FromArgb(255,60, 179, 113);
        private static readonly Color m_MediumSlateBlue = Color.FromArgb(255,123, 104, 238);
        private static readonly Color m_MediumSpringGreen = Color.FromArgb(255,0, 250, 154);
        private static readonly Color m_MediumTurquoise = Color.FromArgb(255,72, 209, 204);
        private static readonly Color m_MediumVioletRed = Color.FromArgb(255,199, 21, 133);
        private static readonly Color m_MidnightBlue = Color.FromArgb(255,25, 25, 112);
        private static readonly Color m_MintCream = Color.FromArgb(255,245, 255, 250);
        private static readonly Color m_MistyRose = Color.FromArgb(255,255, 228, 225);
        private static readonly Color m_Moccasin = Color.FromArgb(255,255, 228, 181);
        private static readonly Color m_NavajoWhite = Color.FromArgb(255,255, 222, 173);
        private static readonly Color m_Navy = Color.FromArgb(255,0, 0, 128);
        private static readonly Color m_OldLace = Color.FromArgb(255,253, 245, 230);
        private static readonly Color m_Olive = Color.FromArgb(255,128, 128, 0);
        private static readonly Color m_OliveDrab = Color.FromArgb(255,107, 142, 35);
        private static readonly Color m_Orange = Color.FromArgb(255,255, 165, 0);
        private static readonly Color m_OrangeRed = Color.FromArgb(255,255, 69, 0);
        private static readonly Color m_Orchid = Color.FromArgb(255,218, 112, 214);
        private static readonly Color m_PaleGoldenrod = Color.FromArgb(255,238, 232, 170);
        private static readonly Color m_PaleGreen = Color.FromArgb(255,152, 251, 152);
        private static readonly Color m_PaleTurquoise = Color.FromArgb(255,175, 238, 238);
        private static readonly Color m_PaleVioletRed = Color.FromArgb(255,219, 112, 147);
        private static readonly Color m_PapayaWhip = Color.FromArgb(255,255, 239, 213);
        private static readonly Color m_PeachPuff = Color.FromArgb(255,255, 218, 185);
        private static readonly Color m_Peru = Color.FromArgb(255,205, 133, 63);
        private static readonly Color m_Pink = Color.FromArgb(255,255, 192, 203);
        private static readonly Color m_Plum = Color.FromArgb(255,221, 160, 221);
        private static readonly Color m_PowderBlue = Color.FromArgb(255,176, 224, 230);
        private static readonly Color m_Purple = Color.FromArgb(255,128, 0, 128);
        private static readonly Color m_Red = Color.FromArgb(255,255, 0, 0);
        private static readonly Color m_RosyBrown = Color.FromArgb(255,188, 143, 143);
        private static readonly Color m_RoyalBlue = Color.FromArgb(255,65, 105, 225);
        private static readonly Color m_SaddleBrown = Color.FromArgb(255,139, 69, 19);
        private static readonly Color m_Salmon = Color.FromArgb(255,250, 128, 114);
        private static readonly Color m_SandyBrown = Color.FromArgb(255,244, 164, 96);
        private static readonly Color m_SeaGreen = Color.FromArgb(255,46, 139, 87);
        private static readonly Color m_SeaShell = Color.FromArgb(255,255, 245, 238);
        private static readonly Color m_Sienna = Color.FromArgb(255,160, 82, 45);
        private static readonly Color m_Silver = Color.FromArgb(255,192, 192, 192);
        private static readonly Color m_SkyBlue = Color.FromArgb(255,135, 206, 235);
        private static readonly Color m_SlateBlue = Color.FromArgb(255,106, 90, 205);
        private static readonly Color m_SlateGray = Color.FromArgb(255,112, 128, 144);
        private static readonly Color m_Snow = Color.FromArgb(255,255, 250, 250);
        private static readonly Color m_SpringGreen = Color.FromArgb(255,0, 255, 127);
        private static readonly Color m_SteelBlue = Color.FromArgb(255,70, 130, 180);
        private static readonly Color m_Tan = Color.FromArgb(255,210, 180, 140);
        private static readonly Color m_Teal = Color.FromArgb(255,0, 128, 128);
        private static readonly Color m_Thistle = Color.FromArgb(255,216, 191, 216);
        private static readonly Color m_Tomato = Color.FromArgb(255,255, 99, 71);
        private static readonly Color m_Turquoise = Color.FromArgb(255,64, 224, 208);
        private static readonly Color m_Violet = Color.FromArgb(255,238, 130, 238);
        private static readonly Color m_Wheat = Color.FromArgb(255,245, 222, 179);
        private static readonly Color m_White = Color.FromArgb(255,255, 255, 255);
        private static readonly Color m_WhiteSmoke = Color.FromArgb(255,245, 245, 245);
        private static readonly Color m_Yellow = Color.FromArgb(255,255, 255, 0);
        private static readonly Color m_YellowGreen = Color.FromArgb(255,154, 205, 50);

        public static Color Transparent { get { return m_Transparent; } }

        public static Color AliceBlue { get { return m_AliceBlue; } }

        public static Color AntiqueWhite { get { return m_AntiqueWhite; } }

        public static Color Aqua { get { return m_Aqua; } }

        public static Color Aquamarine { get { return m_Aquamarine; } }

        public static Color Azure { get { return m_Azure; } }

        public static Color Beige { get { return m_Beige; } }

        public static Color Bisque { get { return m_Bisque; } }

        public static Color Black { get { return m_Black; } }

        public static Color BlanchedAlmond { get { return m_BlanchedAlmond; } }

        public static Color Blue { get { return m_Blue; } }

        public static Color BlueViolet { get { return m_BlueViolet; } }

        public static Color Brown { get { return m_Brown; } }

        public static Color BurlyWood { get { return m_BurlyWood; } }

        public static Color CadetBlue { get { return m_CadetBlue; } }

        public static Color Chartreuse { get { return m_Chartreuse; } }

        public static Color Chocolate { get { return m_Chocolate; } }

        public static Color Coral { get { return m_Coral; } }

        public static Color CornflowerBlue { get { return m_CornflowerBlue; } }

        public static Color Cornsilk { get { return m_Cornsilk; } }

        public static Color Crimson { get { return m_Crimson; } }

        public static Color Cyan { get { return m_Cyan; } }

        public static Color DarkBlue { get { return m_DarkBlue; } }

        public static Color DarkCyan { get { return m_DarkCyan; } }

        public static Color DarkGoldenrod { get { return m_DarkGoldenrod; } }

        public static Color DarkGray { get { return m_DarkGray; } }

        public static Color DarkGreen { get { return m_DarkGreen; } }

        public static Color DarkKhaki { get { return m_DarkKhaki; } }

        public static Color DarkMagenta { get { return m_DarkMagenta; } }

        public static Color DarkOliveGreen { get { return m_DarkOliveGreen; } }

        public static Color DarkOrange { get { return m_DarkOrange; } }

        public static Color DarkOrchid { get { return m_DarkOrchid; } }

        public static Color DarkRed { get { return m_DarkRed; } }

        public static Color DarkSalmon { get { return m_DarkSalmon; } }

        public static Color DarkSeaGreen { get { return m_DarkSeaGreen; } }

        public static Color DarkSlateBlue { get { return m_DarkSlateBlue; } }

        public static Color DarkSlateGray { get { return m_DarkSlateGray; } }

        public static Color DarkTurquoise { get { return m_DarkTurquoise; } }

        public static Color DarkViolet { get { return m_DarkViolet; } }

        public static Color DeepPink { get { return m_DeepPink; } }

        public static Color DeepSkyBlue { get { return m_DeepSkyBlue; } }

        public static Color DimGray { get { return m_DimGray; } }

        public static Color DodgerBlue { get { return m_DodgerBlue; } }

        public static Color Firebrick { get { return m_Firebrick; } }

        public static Color FloralWhite { get { return m_FloralWhite; } }

        public static Color ForestGreen { get { return m_ForestGreen; } }

        public static Color Fuchsia { get { return m_Fuchsia; } }

        public static Color Gainsboro { get { return m_Gainsboro; } }

        public static Color GhostWhite { get { return m_GhostWhite; } }

        public static Color Gold { get { return m_Gold; } }

        public static Color Goldenrod { get { return m_Goldenrod; } }

        public static Color Gray { get { return m_Gray; } }

        public static Color Green { get { return m_Green; } }

        public static Color GreenYellow { get { return m_GreenYellow; } }

        public static Color Honeydew { get { return m_Honeydew; } }

        public static Color HotPink { get { return m_HotPink; } }

        public static Color IndianRed { get { return m_IndianRed; } }

        public static Color Indigo { get { return m_Indigo; } }

        public static Color Ivory { get { return m_Ivory; } }

        public static Color Khaki { get { return m_Khaki; } }

        public static Color Lavender { get { return m_Lavender; } }

        public static Color LavenderBlush { get { return m_LavenderBlush; } }

        public static Color LawnGreen { get { return m_LawnGreen; } }

        public static Color LemonChiffon { get { return m_LemonChiffon; } }

        public static Color LightBlue { get { return m_LightBlue; } }

        public static Color LightCoral { get { return m_LightCoral; } }

        public static Color LightCyan { get { return m_LightCyan; } }

        public static Color LightGoldenrodYellow { get { return m_LightGoldenrodYellow; } }

        public static Color LightGreen { get { return m_LightGreen; } }

        public static Color LightGray { get { return m_LightGray; } }

        public static Color LightPink { get { return m_LightPink; } }

        public static Color LightSalmon { get { return m_LightSalmon; } }

        public static Color LightSeaGreen { get { return m_LightSeaGreen; } }

        public static Color LightSkyBlue { get { return m_LightSkyBlue; } }

        public static Color LightSlateGray { get { return m_LightSlateGray; } }

        public static Color LightSteelBlue { get { return m_LightSteelBlue; } }

        public static Color LightYellow { get { return m_LightYellow; } }

        public static Color Lime { get { return m_Lime; } }

        public static Color LimeGreen { get { return m_LimeGreen; } }

        public static Color Linen { get { return m_Linen; } }

        public static Color Magenta { get { return m_Magenta; } }

        public static Color Maroon { get { return m_Maroon; } }

        public static Color MediumAquamarine { get { return m_MediumAquamarine; } }

        public static Color MediumBlue { get { return m_MediumBlue; } }

        public static Color MediumOrchid { get { return m_MediumOrchid; } }

        public static Color MediumPurple { get { return m_MediumPurple; } }

        public static Color MediumSeaGreen { get { return m_MediumSeaGreen; } }

        public static Color MediumSlateBlue { get { return m_MediumSlateBlue; } }

        public static Color MediumSpringGreen { get { return m_MediumSpringGreen; } }

        public static Color MediumTurquoise { get { return m_MediumTurquoise; } }

        public static Color MediumVioletRed { get { return m_MediumVioletRed; } }

        public static Color MidnightBlue { get { return m_MidnightBlue; } }

        public static Color MintCream { get { return m_MintCream; } }

        public static Color MistyRose { get { return m_MistyRose; } }

        public static Color Moccasin { get { return m_Moccasin; } }

        public static Color NavajoWhite { get { return m_NavajoWhite; } }

        public static Color Navy { get { return m_Navy; } }

        public static Color OldLace { get { return m_OldLace; } }

        public static Color Olive { get { return m_Olive; } }

        public static Color OliveDrab { get { return m_OliveDrab; } }

        public static Color Orange { get { return m_Orange; } }

        public static Color OrangeRed { get { return m_OrangeRed; } }

        public static Color Orchid { get { return m_Orchid; } }

        public static Color PaleGoldenrod { get { return m_PaleGoldenrod; } }

        public static Color PaleGreen { get { return m_PaleGreen; } }

        public static Color PaleTurquoise { get { return m_PaleTurquoise; } }

        public static Color PaleVioletRed { get { return m_PaleVioletRed; } }

        public static Color PapayaWhip { get { return m_PapayaWhip; } }

        public static Color PeachPuff { get { return m_PeachPuff; } }

        public static Color Peru { get { return m_Peru; } }

        public static Color Pink { get { return m_Pink; } }

        public static Color Plum { get { return m_Plum; } }

        public static Color PowderBlue { get { return m_PowderBlue; } }

        public static Color Purple { get { return m_Purple; } }

        public static Color Red { get { return m_Red; } }

        public static Color RosyBrown { get { return m_RosyBrown; } }

        public static Color RoyalBlue { get { return m_RoyalBlue; } }

        public static Color SaddleBrown { get { return m_SaddleBrown; } }

        public static Color Salmon { get { return m_Salmon; } }

        public static Color SandyBrown { get { return m_SandyBrown; } }

        public static Color SeaGreen { get { return m_SeaGreen; } }

        public static Color SeaShell { get { return m_SeaShell; } }

        public static Color Sienna { get { return m_Sienna; } }

        public static Color Silver { get { return m_Silver; } }

        public static Color SkyBlue { get { return m_SkyBlue; } }

        public static Color SlateBlue { get { return m_SlateBlue; } }

        public static Color SlateGray { get { return m_SlateGray; } }

        public static Color Snow { get { return m_Snow; } }

        public static Color SpringGreen { get { return m_SpringGreen; } }

        public static Color SteelBlue { get { return m_SteelBlue; } }

        public static Color Tan { get { return m_Tan; } }

        public static Color Teal { get { return m_Teal; } }

        public static Color Thistle { get { return m_Thistle; } }

        public static Color Tomato { get { return m_Tomato; } }

        public static Color Turquoise { get { return m_Turquoise; } }

        public static Color Violet { get { return m_Violet; } }

        public static Color Wheat { get { return m_Wheat; } }

        public static Color White { get { return m_White; } }

        public static Color WhiteSmoke { get { return m_WhiteSmoke; } }

        public static Color Yellow { get { return m_Yellow; } }

        public static Color YellowGreen { get { return m_YellowGreen; } }
    }
}
