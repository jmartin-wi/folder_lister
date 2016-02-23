using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;

namespace Folder_Lister
{
    class Util
    {
        internal static bool FileOrDirectoryExists(string name)
        {
            return (Directory.Exists(name) || File.Exists(name));
        }

        public static string GetBytesReadable(long i)
        {
            // Get absolute value
            long absolute_i = (i < 0 ? -i : i);
            // Determine the suffix and readable value
            string suffix;
            double readable;
            if (absolute_i >= 0x1000000000000000) // Exabyte
            {
                suffix = "EB";
                readable = (i >> 50);
            }
            else if (absolute_i >= 0x4000000000000) // Petabyte
            {
                suffix = "PB";
                readable = (i >> 40);
            }
            else if (absolute_i >= 0x10000000000) // Terabyte
            {
                suffix = "TB";
                readable = (i >> 30);
            }
            else if (absolute_i >= 0x40000000) // Gigabyte
            {
                suffix = "GB";
                readable = (i >> 20);
            }
            else if (absolute_i >= 0x100000) // Megabyte
            {
                suffix = "MB";
                readable = (i >> 10);
            }
            else if (absolute_i >= 0x400) // Kilobyte
            {
                suffix = "KB";
                readable = i;
            }
            else
            {
                return i.ToString("0 B"); // Byte
            }
            // Divide by 1024 to get fractional value
            readable = (readable / 1024);
            // Return formatted number with suffix
            return readable.ToString("0.# ") + suffix;
        }

        public static void send_To_Word(List<DTO.DocTree> dtoLeaves)
        {
            if (dtoLeaves.Count() < 1)
            {
                return;
            }
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            //Start Word and create a new document. https://support.microsoft.com/en-us/kb/316384
            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
                ref oMissing, ref oMissing);

            //Insert a paragraph at the beginning of the document.
            string dtNow = DateTime.Now.ToString();
            Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Text = "Listing for: " + dtoLeaves[0].TreeName + "\rCount: " + dtoLeaves.Count.ToString() + "\rPrint time: " + dtNow;
            oPara1.Range.Font.Bold = 1;

            //change font size for in-line text page headers
            Word.Range rng = oPara1.Range;
            object findText = "Listing for:";
            rng.Find.ClearFormatting();
            if (rng.Find.Execute(ref findText,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing))
            {
                rng.Font.Bold = 0;
                rng.Font.Size = 10;
            }
            findText = "Count:";
            rng.Find.ClearFormatting();
            if (rng.Find.Execute(ref findText,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing))
            {
                rng.Font.Bold = 0;
                rng.Font.Size = 10;
            }
            findText = "Print time:";
            rng.Find.ClearFormatting();
            if (rng.Find.Execute(ref findText,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing))
            {
                rng.Font.Bold = 0;
                rng.Font.Size = 10;
            }
            oPara1.Range.InsertParagraphAfter();

            //Insert another paragraph
            Word.Paragraph oPara2;
            oPara2 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara2.Range.Text = "Comment: " + dtoLeaves[0].TreeComment;
            oPara2.Range.Font.Bold = 1;
            oPara2.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.

            rng = oPara2.Range;
            findText = "Comment:";
            rng.Find.ClearFormatting();
            if (rng.Find.Execute(ref findText,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing))
            {
                rng.Font.Bold = 0;
                rng.Font.Size = 10;
            }
            oPara2.Range.InsertParagraphAfter();

            //Insert a 3 x 5 table, fill it with data, and make the first row
            //bold and italic.
            Word.Table oTable;
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, dtoLeaves.Count()+1, 5, ref oMissing, ref oMissing);
            oTable.Range.ParagraphFormat.SpaceAfter = 6;
            oTable.Range.Font.Size = 8;
            oTable.set_Style("Table Colorful 3");

            //set table column widths
            //oTable.Columns.DistributeWidth();
            //oTable.Columns[0].PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPoints;
            //oTable.Columns[0].PreferredWidth = 99f;
            //oTable.Columns[0].SetWidth(170, Word.WdRulerStyle.wdAdjustNone);
            //oTable.Columns[1].SetWidth(ColumnWidth: 170, RulerStyle: Word.WdRulerStyle.wdAdjustNone);
            //oTable.Columns[2].SetWidth(ColumnWidth: 170, RulerStyle: Word.WdRulerStyle.wdAdjustNone);
            //oTable.Columns[3].SetWidth(ColumnWidth: 170, RulerStyle: Word.WdRulerStyle.wdAdjustNone);

            string strText;
            long lngSize;
            string readableSize;
            oTable.Cell(1, 1).Range.Text = "Name";
            oTable.Cell(1, 1).Width = 250;
            oTable.Rows[1].Range.Font.Bold = 1;
            oTable.Rows[1].Range.Font.Italic = 1;
            //oTable.Rows[1].Range.Font.Size = 12;

            oTable.Cell(1, 2).Range.Text = "Category";
            oTable.Cell(1, 2).Width = 50;

            oTable.Cell(1, 3).Range.Text = "Size";
            oTable.Cell(1, 3).Width = 50;
            oTable.Cell(1, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;

            oTable.Cell(1, 4).Range.Text = "Comment";
            oTable.Cell(1, 4).Width = 100;

            oTable.Cell(1, 5).Range.Text = "Area";
            oTable.Cell(1, 5).Width = 30;
            oTable.Cell(1, 5).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;

            for (var i = 1; i <= dtoLeaves.Count(); i++)
            {
                strText = dtoLeaves[i - 1].LeafName.Replace("'", "");
                oTable.Cell(i + 1, 1).Range.Text = strText;
                oTable.Cell(i + 1, 1).Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Cell(i + 1, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oTable.Cell(i + 1, 1).Width = 250;

                strText = dtoLeaves[i - 1].LeafCategory.Replace("'","");
                oTable.Cell(i + 1, 2).Range.Text = strText;
                oTable.Cell(i + 1, 2).Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Cell(i + 1, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oTable.Cell(i + 1, 2).Width = 50;

                strText = dtoLeaves[i - 1].LeafSize;
                long.TryParse(strText, out lngSize);
                readableSize = Util.GetBytesReadable(lngSize);
                oTable.Cell(i + 1, 3).Range.Text = readableSize;
                oTable.Cell(i + 1, 3).Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Cell(i + 1, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                oTable.Cell(i + 1, 3).Width = 50;

                strText = dtoLeaves[i - 1].LeafComment.Replace("'", "");
                oTable.Cell(i + 1, 4).Range.Text = strText;
                oTable.Cell(i + 1, 4).Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Cell(i + 1, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oTable.Cell(i + 1, 4).Width = 100;

                strText = dtoLeaves[i - 1].LeafLocation.Replace("'", "");
                oTable.Cell(i + 1, 5).Range.Text = strText;
                oTable.Cell(i + 1, 5).Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                oTable.Cell(i + 1, 5).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                oTable.Cell(i + 1, 5).Width = 30;
            }
            oTable.Range.ParagraphFormat.SpaceAfter = 1;
            oWord.ActiveDocument.ShowSpellingErrors = false;
            oWord.ActiveDocument.ShowGrammaticalErrors = false;
            oWord.ActiveDocument.BuiltInDocumentProperties("Title").Value = "Folder_Listing_" + dtoLeaves[0].TreeName + DateTime.Now.ToString("YYMMDDHHMMss");
        }
    }
}
