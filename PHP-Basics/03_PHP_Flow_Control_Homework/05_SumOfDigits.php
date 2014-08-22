<!DOCTYPE html>
<html>
	<head>
		<title>Sum Of Digits</title>
		<meta charset = "UTF-8"/>
		<style>
		table.table {
			border: 1px solid black;
		}
		tr, td {
			border: 1px solid black;
			padding: 3px;
		}
			
		</style>
	</head>
	<body>
		<form  action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>" method="post">
			Input string: <input type="text" name="numbers" placeholder="Enter numbers" required/>
			            <input type="submit" name="submit" value="Submit"/>
		</form><br/>
		
		<?php
		if(isset($_POST['numbers'])){
			$table = "<table class=\"table\">";
			$nums = explode(", ",$_POST['numbers']);
			for ($i=0; $i < count($nums) ; $i++) {
				if(intval($nums[$i]) == 0){
					$table .= "<tr><td>".htmlentities($nums[$i])."</td><td>I cannot sum that</td></tr>"; 
				} else {
					 $num_as_string = strval($nums[$i]);
					 $sum = 0;
					 for ($j=0; $j < strlen($num_as_string) ; $j++) { 
						 $sum += intval($num_as_string[$j]);
					 }
					 
					 
					 $table .= "<tr><td>".htmlentities($nums[$i])."</td><td>".$sum."</td></tr>"; 
				}
				
			}
			$table .= "</table>";
			echo $table;		
		}
		?>
	</body
</html>