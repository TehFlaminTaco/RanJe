using System.Text;
namespace RanJe{
    class SMBC : Encoding{
        private static char[] _CodePage = {
            '¡','¢','£','¤','¥','¦','©','¬','®','µ','½','¿','€','Æ','Ç','Ð','Ñ','×','Ø','Œ','Þ','ß','æ','ç','ð','ı','ȷ','ñ','÷','ø','œ','þ',' ','!','"','#','$','%','&','\'','(',')','*','+',',','-','.','/','0','1','2','3','4','5','6','7','8','9',':',';','<','=','>','?','@','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','[','\\',']','^','_','`','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','{','|','}','~','\n',
            '°','¹','²','³','⁴','⁵','⁶','⁷','⁸','⁹','⁺','⁻','⁼','⁽','⁾','Ɓ','Ƈ','Ɗ','Ƒ','Ɠ','Ƙ','Ɱ','Ɲ','Ƥ','Ƭ','Ʋ','Ȥ','ɓ','ƈ','ɗ','ƒ','ɠ','ɦ','ƙ','ɱ','ɲ','ƥ','ʠ','ɼ','ʂ','ƭ','ʋ','ȥ','Ạ','Ḅ','Ḍ','Ẹ','Ḥ','Ị','Ḳ','Ḷ','Ṃ','Ṇ','Ọ','Ṛ','Ṣ','Ṭ','Ụ','Ṿ','Ẉ','Ỵ','Ẓ','Ȧ','Ḃ','Ċ','Ḋ','Ė','Ḟ','Ġ','Ḣ','İ','Ŀ','Ṁ','Ṅ','Ȯ','Ṗ','Ṙ','Ṡ','Ṫ','Ẇ','Ẋ','Ẏ','Ż','ạ','ḅ','ḍ','ẹ','ḥ','ị','ḳ','ḷ','ṃ','ṇ','ọ','ṛ','ṣ','ṭ','§','Ä','ẉ','ỵ','ẓ','ȧ','ḃ','ċ','ḋ','ė','ḟ','ġ','ḣ','ŀ','ṁ','ṅ','ȯ','ṗ','ṙ','ṡ','ṫ','ẇ','ẋ','ẏ','ż','«','»','‘','’','“','”'
        };

        public static SMBC Encoding = new SMBC();

        override public int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex){
            // Ensure it fits. Errors are for quitters.
            if(byteIndex + byteCount > (bytes.Length + 1)){
                byteCount = bytes.Length - byteIndex;
            }
            if(charIndex + byteCount > chars.Length + 1){
                byteCount = chars.Length - charIndex;
            }

            for(int i=0; i < byteCount; i++){
                chars[charIndex + i] = _CodePage[bytes[byteIndex + i]];
            }

            return byteCount;
        }

        override public int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex){
            // Ensure it fits. Errors are for quitters.
            if(charIndex + charCount > bytes.Length + 1){
                charCount = bytes.Length - charIndex;
            }
            if(byteIndex + charCount > chars.Length + 1){
                charCount = chars.Length - byteIndex;
            }

            for(int i=0; i < charCount; i++){
                char curChar = chars[charIndex + i];
                bool found = false;
                for(int c = 0; c < 256; c++){
                    if(_CodePage[c] == curChar){
                        bytes[byteIndex + i] = (byte)c;
                        found = true;
                        break;
                    }
                    if(found){
                        break;
                    }
                }
                if(!found){
                    bytes[byteIndex + i] = 0x3F; // ?
                }
            }

            return charCount;
        }

        override public int GetCharCount(byte[] bytes, int index, int count){
            if(index + count > bytes.Length + 1){
                count = bytes.Length - count;
            }
            return count;
        }

        override public int GetByteCount(char[] chars, int index, int count){
            if(index + count > chars.Length + 1){
                count = chars.Length - count;
            }
            return count;
        }

        override public int GetMaxByteCount(int charCount){
            return charCount;
        }

        override public int GetMaxCharCount(int byteCount){
            return byteCount;
        }
    }
}