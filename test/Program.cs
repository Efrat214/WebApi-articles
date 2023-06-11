using BLL;

internal class Program
{
    private static void Main(string[] args)
    {
        //traningModel traningModel = new traningModel();
        //traningModel.readData();
        OcrHelper ironOcr1 = new OcrHelper(@"C:\Users\1\Desktop\מאמרים לניסוי\music.pdf");
        string content = ironOcr1.ReadPdf(); // Use "ReadPdf()" instead of "readPdf()"
    }
}
