using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PdfFileWriter;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;

namespace BrunTomoProject
{
    class CreateReport
    {

        // Draw example of a text box
        private static void DrawTextBox(PdfDocument document, PdfPage page)
        {
            PdfContents zContents = new PdfContents(page);

            PdfFont zArialNormal = new PdfFont(document, "Arial", FontStyle.Regular, true);
            zArialNormal.CharSubstitution(945, 950, 161);

            // Save graphics state:
            zContents.SaveGraphicsState();

            // translate origin to PosX=1.1" and PosY=1.1" this is the bottom left corner of the text box example
            zContents.Translate(1.1, 1.1);

            // Define constants
            // Box width 3.25"
            // Box height is 3.65"
            // Normal font size is 9.0 points.
            const Double Width = 3.15;
            const Double Height = 3.65;
            const Double FontSize = 9.0;

            // Create text box object width 3.25"
            // First line indent of 0.25"
            TextBox Box = new TextBox(Width, 0.25);

            // add text to the text box
            Box.AddText(zArialNormal, FontSize,
                "This area is an example of displaying text that is too long to fit within a fixed width " +
                "area. The text is displayed justified to right edge. You define a text box with the required " +
                "width and first line indent. You add text to this box. The box will divide the text into " +
                "lines. Each line is made of segments of text. For each segment, you define font, font " +
                "size, drawing style and color. After loading all the text, the program will draw the formatted text.\n");

            Box.AddText(zArialNormal, FontSize - 2.0, "Arial size 7, ");
            Box.AddText(zArialNormal, FontSize - 1.0, "size 8, ");
            Box.AddText(zArialNormal, FontSize, "size 9, ");
            Box.AddText(zArialNormal, FontSize + 1.0, "size 10. ");
            Box.AddText(zArialNormal, FontSize, DrawStyle.Underline, "Underline, ");
            Box.AddText(zArialNormal, FontSize, DrawStyle.Strikeout, "Strikeout. ");
            Box.AddText(zArialNormal, FontSize, "Subscript H");
            Box.AddText(zArialNormal, FontSize, DrawStyle.Subscript, "2");
            Box.AddText(zArialNormal, FontSize, "O. Superscript A");
            Box.AddText(zArialNormal, FontSize, DrawStyle.Superscript, "2");
            Box.AddText(zArialNormal, FontSize, "+B");
            Box.AddText(zArialNormal, FontSize, DrawStyle.Superscript, "2");
            Box.AddText(zArialNormal, FontSize, "=C");
            Box.AddText(zArialNormal, FontSize, DrawStyle.Superscript, "2");
            Box.AddText(zArialNormal, FontSize, "\n");
            
            Box.AddText(zArialNormal, FontSize, "\n");

            // Draw the text box
            // Text left edge is at zero (note: origin was translated to 1.1") 
            // The top text base line is at Height less first line ascent.
            // Text drawing is limited to vertical coordinate of zero.
            // First line to be drawn is line zero.
            // After each line add extra 0.015".
            // After each paragraph add extra 0.05"
            // Stretch all lines to make smooth right edge at box width of 3.15"
            // After all lines are drawn, PosY will be set to the next text line after the box's last paragraph
            Double PosY = Height;
            zContents.DrawText(0.0, ref PosY, 0.0, 0, 0.015, 0.05, TextBoxJustify.FitToWidth, Box);

            // Create text box object width 3.25"
            // No first line indent
            Box = new TextBox(Width);

            // Add text as before.
            // No extra line spacing.
            // No right edge adjustment
            Box.AddText(zArialNormal, FontSize,
                "In the examples above this area the text box was set for first line indent of " +
                "0.25 inches. This paragraph has zero first line indent and no right justify.");
            zContents.DrawText(0.0, ref PosY, 0.0, 0, 0.01, 0.05, TextBoxJustify.Left, Box);

            // Create text box object width 2.75
            // First line hanging indent of 0.5"
            Box = new TextBox(Width - 0.5, -0.5);

            // Add text
            Box.AddText(zArialNormal, FontSize,
                "This paragraph is set to first line hanging indent of 0.5 inches. " +
                "The left margin of this paragraph is 0.5 inches.");

            // Draw the text
            // left edge at 0.5"
            zContents.DrawText(0.5, ref PosY, 0.0, 0, 0.01, 0.05, TextBoxJustify.Left, Box);

            // restore graphics state
            zContents.RestoreGraphicsState();
        }


        // Create &ldquo;article example&rdquo; test PDF document
        public static void CreatePDF(String FileName)
        {
            // Step 1: Create empty document
            // Arguments: page width: 8.5&rdquo;, page height: 11&rdquo;, Unit of measure: inches
            // Return value: PdfDocument main class
            // create main class
            PdfDocument zDocument = new PdfDocument(PaperType.Letter, false, UnitOfMeasure.Inch, FileName);
            PdfPage zPage = new PdfPage(zDocument);

            DrawTextBox(zDocument, zPage);

            // Step 6: create pdf file
            // argument: PDF file name
            zDocument.CreateFile();
        }
    }
}
