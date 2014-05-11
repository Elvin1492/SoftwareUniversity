import com.itextpdf.text.BaseColor;
import com.itextpdf.text.Document;
import com.itextpdf.text.Font;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.pdf.BaseFont;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;
import java.io.FileOutputStream;

public class DeckOf52Cards {

	public static void main(String[] args) {
		//For the implementation of this task we'll be using an external library 'itext'.
		//We have to import the itextpdf-5. t5.0.jar 
		String result = " ";
		char color = ' ';
		
		String jack = "J";
		String queen = "Q";
		String king = "K";
		String ace = "A";
		
		 char clubs = '\u2663';
         char diamonds = '\u2666';
         char hearts = '\u2665';
         char spades = '\u2660';
         
		try{
					
		//Create a new blank file and open it
		Document document = new Document();
		PdfWriter.getInstance(document, new FileOutputStream("deck-of-cards.pdf"));
		document.open();
		
		//Create the tables for the cards in the file
		PdfPTable table = new PdfPTable(4);
		table.setWidthPercentage(75);
		table.getDefaultCell().setFixedHeight(110);
		table.getDefaultCell().setPadding(2);
		
		//Set the font
		BaseFont baseFont = BaseFont.createFont("C:/Windows/Fonts/Arial.ttf", BaseFont.IDENTITY_H, true);
        Font black = new Font(baseFont, 50f, 0, BaseColor.BLACK);
        Font red = new Font(baseFont, 50f, 0, BaseColor.RED);
        
        //Fill the tables with the cards
        for (int i = 2; i <= 14; i++){            
            for (int j = 1; j <= 4; j++){
                    switch (i){
                            case 10: result = "10"; break;
                            case 11: result = " " + jack; break;
                            case 12: result = " " + queen; break;                          
                            case 13: result = " " + king; break;
                            case 14: result = " " + ace; break;
                            default: result = " " + i; break;
                    }
                    switch(j){
                            case 1:{
                                    color = clubs;
                                    table.addCell(new Paragraph(result + color + " ", black));
                                    break;
                            }
                            case 2:{
                                    color = diamonds;
                                    table.addCell(new Paragraph(result + color + " ", red));
                                    break;
                            }
                            case 3:{
                                    color = hearts;
                                    table.addCell(new Paragraph(result + color + " ", red));
                                    break;
                            }
                            case 4:{
                                    color = spades;
                                    table.addCell(new Paragraph(result + color + " ", black));
                                    break;
                            }
                    }
                    
            }
        }
        //Add the table to the document and close it
        document.add(table);
        document.close();
		}
		catch (Exception e) {
            e.printStackTrace();
		}
	}
}
