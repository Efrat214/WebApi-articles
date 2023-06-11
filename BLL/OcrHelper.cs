using IronOcr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OcrHelper
    {
        string pathToFile;

        public OcrHelper(string pathToArticale)
        {
            this.pathToFile = pathToArticale;
        }

        public string ReadPdf()
        {
            string extension = Path.GetExtension(pathToFile);

            var ocr = new IronTesseract();

            using (var input = new OcrInput())
            {
                if (extension == ".pdf")
                {
                    input.AddPdf(pathToFile);
                }
                else if (extension == ".png")
                {
                    input.AddImage(pathToFile);
                }

                var result = ocr.Read(input);
                string extractedText = result.Text; // Extracted text from the PDF or image

                return extractedText;
            }
        }
    }
}

