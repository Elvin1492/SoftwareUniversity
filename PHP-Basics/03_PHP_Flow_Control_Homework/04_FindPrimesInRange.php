<!DOCTYPE html>
<html>
	<head>
		<title>Find Primes in Range</title>
		<meta charset = "UTF-8"/>
	</head>
	<body>
		<form  action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>" method="post">
			Starting Index: <input type="number" name="start" placeholder="Enter start index" required/>
			End: <input type="number" name="end" placeholder="Enter end index" required/>
			            <input type="submit" name="submit" value="Submit"/>
		</form><br/>
		
		<?php
		if(isset($_POST['start']) && isset($_POST['end']) ){
			$start = $_POST['start'];
			$end =  $_POST['end'];
			$output = "<div>";
			for ($i= $start; $i <= $end ; $i++) {
				$isPrime = true;
				$max_divider = sqrt($i);
				//check if the number is prime
				for ($j=2; $j <= $max_divider; $j++) { 
					if($i % $j === 0){
						$isPrime = false;
						break;
					}
				}
				//print the number 
				if($isPrime){
					$output .= "<span><strong>".$i.", </strong></span>";

				} else if(!($isPrime)) {
					$output .= "<span>".$i.", </span>";
				}		
			}	
			$output .= "</div>";
			echo $output;
		}
		?>
	</body
</html>