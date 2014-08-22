<!DOCTYPE html>
<html>
	<head>
		<title>Words Counter</title>
		<meta charset ='UTF-8' />
		<style>
			table, tr, td {
				border: 1px solid black;
			}
			table {
				border-collapse: collapse;
			}
		</style>
	</head>
	<body>
		<form method="post" action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>">
			<textarea rows="4" cols="50" placeholder = "Enter text here" name="text">
				
			</textarea><br />
			<input type="submit" name="submit" value="Count words" />
		</form><br />
	<?php
	header("Content-Type: text/html; charset=utf-8");
	mb_internal_encoding("utf-8");
	 if( (isset($_POST['text'])) && (!empty($_POST['text'])) && (isset($_POST['submit'])) ){	 			
		$text = strtolower($_POST['text']);
		$pattern = '/\W+/';
		$words = preg_split($pattern, $text,-1,PREG_SPLIT_NO_EMPTY);
		// $wordsCount = array_count_values($words); --- built in PHP function
		 $words_count = array();
		 foreach ($words as  $word) {
		 	if(isset($words_count[$word])){
		 		$words_count[$word]++;
		 	} else {
		 		$words_count[$word] = 1;
		 	}		 
		 }	 
		 $table = "<table>";
		 foreach ($words_count as $key => $value) {
		       	$table .= "<tr><td>".htmlentities($key)."</td><td>$value</td></tr>";
			} 
		 $table .= "</table>";
	 	echo $table;		
	 }
	?>

	</body>
</html>



