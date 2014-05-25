import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class ExtractEmails {
	//Write a program to extract all email addresses from given text. The text comes at the first 
	//input line. Print the emails in the output, each at a separate line. Emails are considered
	//to be in format <user>@<host>, 

	public static void main(String[] args) {
		//read the input
		Scanner reader = new Scanner(System.in);
		String text = reader.nextLine();
		
		//Create a pattern for e-mails
		String emailRegEx = "[\\w-+]+(?:\\.[\\w-+]+)*@(?:[\\w-]+\\.)+[a-zA-Z]{2,7}";
		Pattern emailPattern = Pattern.compile(emailRegEx);
		
		//create a matcher to search the text for e-mail patterns
		Matcher match = emailPattern.matcher(text);
		while (match.find()) {
			System.out.println(match.group());
			
		}
		
		
		
		

	}

}
