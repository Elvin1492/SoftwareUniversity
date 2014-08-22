<!DOCTYPE html>
<html>
	<head>
		<title>Show Annual Expence</title>
		<meta charset = "UTF-8"/>
		<style>
		table.table {
			border: 1px solid black;
		}
		tr, th, td {
			border: 1px solid black;
			padding: 3px;
		}
			
		</style>
	</head>
	<body>
		<form  action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>" method="post">
			Enter Number of years: <input type="number" name="years" placeholder="enter year" required/>
			            <input type="submit" name="submit" value="Show costs"/>
		</form><br/>
		
		<?php
		if(isset($_POST['years'])){
			$table = "<table class=\"table\"><thead><tr><th>Year</th><th>January</th><th>February</th><th>March</th>
			<th>April</th><th>May</th><th>June</th><th>July</th><th>August</th><th>September</th><th>October</th><th>November</th>
			<th>December</th><th>Total</th></tr></thead><tbody>";
			$n = $_POST['years'];
			$current_year = date('Y');
			for ($i= $current_year; $i > ($current_year - $n); $i--) {
                $total = 0;
				$table .= "<tr><td>$i</td>";
				for ($j=0; $j < 12 ; $j++) { 
					$random_sum = (int)rand(0, 999);
					$total += $random_sum;
					$table .= "<td>$random_sum</td>";
				}
				$table .= "<td>".$total."</td></tr>";
			}
		
			$table .= "</tbody></table>";
			echo $table;		
		}
		?>
	</body
</html>