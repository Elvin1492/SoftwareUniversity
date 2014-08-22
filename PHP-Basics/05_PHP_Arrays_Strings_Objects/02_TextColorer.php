<!DOCTYPE html>
<html>
	<head>
		<title>Text colorer</title>
		<meta charset ='UTF-8' />
		<style>
			span.red {
				color: red;
				padding-right: 3px;
			}
			span.blue {
				color: blue;
				padding-right: 3px;
			}
		</style>
	</head>
	<body>
		<form method="post" action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>">
			<textarea rows="4" cols="50" placeholder = "Enter text here" name="text">
				
			</textarea><br />
			<input type="submit" name="submit" value="Color text" />
		</form><br />
	<?php
	 if( (isset($_POST['text'])) && (!empty($_POST['text'])) && (isset($_POST['submit'])) ){	 			
		$text = $_POST['text'];
		$pattern = '/\s*/';
        $chars = preg_split($pattern, $text, -1,PREG_SPLIT_NO_EMPTY);
		$output = "";
		foreach ($chars as $char) {
			$class = '';
			$position = ord($char);
			if($position % 2 == 0){
				$class = 'red';
			} else {
				$class = 'blue';
			}
			$output .= "<span class=\"$class\">$char</span>";
		}
		echo $output;
	 }
	?>
</body>
</html>



