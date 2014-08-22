<!DOCTYPE html>
<html>
	<head>
		<title>Modify String</title>
		<meta charset = "UTF-8"/>
	</head>
	<body>
		<form  action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>" method="post">
			Enter string: <input type="text" name="string" placeholder="Enter string" required/>			            
						  <input type="radio" name="modify" value="palindorme" id="palindrome"/>
						  <label for="palindrome">Check Palindrome</label>						  
						  <input type="radio" name="modify" value="reverse" id="reverse"/>
						  <label for="reverse">Reverse String</label>						  
						  <input type="radio" name="modify" value="split" id="split"/>
						  <label for="split">Split</label>						  
						  <input type="radio" name="modify" value="hash" id="hash"/>
						  <label for="hash">Hash String</label>						  
						  <input type="radio" name="modify" value="shuffle" id="shuffle"/>
						  <label for="shuffle">Shuffle String</label>
			              <input type="submit" name="submit" value="Submit"/>
		</form><br/>
		
		<?php
		if(isset($_POST['modify']) && isset($_POST['submit'])){
			$action = $_POST['modify'];
			$string = $_POST['string'];
			
			if($action == 'palindorme'){
				$stringToLower = strtolower($string);
				$palindrome = strrev($stringToLower);
				if($stringToLower == $palindrome){
					echo htmlspecialchars($string). " is a palindrome!";
				} else {
					echo htmlspecialchars($string). " is not a palindrome!";
				}
			} else if($action == 'reverse'){
				echo strrev(htmlspecialchars($string));
			} else if($action == 'split'){
				$split = str_split($string);
				foreach ($split as $char) {
					echo $char." ";
				}
			} else if($action == 'hash'){
				echo crypt($string);
			} else if($action == 'shuffle') {
			   echo str_shuffle($string);
				
			}
			
			

		}
		?>
	</body
</html>