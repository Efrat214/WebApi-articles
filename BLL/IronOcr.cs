using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronOcr;
using IronPdf;

namespace BLL
{
    public class IronOcr
    {
        string pathToFile;
        public IronOcr(string pathToArticale)
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
        //public string readPdf()
        //{
        //    string extension = Path.GetExtension(pathToFile);

        //    var Ocr = new IronTesseract(); // nothing to configure
        //    using (var Input = new OcrInput())
        //    {
        //        if (extension == ".pdf")
        //        {
        //            Input.AddPdf(pathToFile, " ");
        //        }
        //        else if (extension == ".png")
        //        {
        //            Input.AddImage(pathToFile, null);
        //        }
        //        //Input.AddPdf(fileName, " ");
        //        var Result = Ocr.Read(Input);
        //        //Console.WriteLine(Result.Text);
        //        //Console.WriteLine(pathToFile);
        //        //IronPdf.License.LicenseKey = "IRONPDF.PORGRAM123456789.25117-F45B2EE91D-DMQOPQS4NT24K634-F37S72YFPKOT-44WCO3XOZRNT-6HSZZZ477KWR-LBNWZGVWWMFL-D2K5QX-TP6PMHTF5O2JUA-DEPLOYMENT.TRIAL-E5DXAT.TRIAL.EXPIRES.30.MAY.2023";

        //        ////    IronPdf.License.LicenseKey = "IRONPDF.L039321443.32380-9C7358473B-7U3NP4KKOMTU3YXK-7GGOUWNBKBHP-MR2WU7ETBNUL-2XO4NJVF2WKQ-5PPP5WJVGCET-BCSMYZ-TC7QALVNL7OJEA-DEPLOYMENT.TRIAL-JKWXVZ.TRIAL.EXPIRES.29.APR.2023";
        //        //using PdfDocument pdf = PdfDocument.FromFile(pathToFile);
        //        //return pdf.ExtractAllText();
        //        return Result;
        //    }

        //}
    }
}

