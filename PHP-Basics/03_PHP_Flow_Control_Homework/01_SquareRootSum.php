<!DOCTYPE html>
<html>
	<head>
		<title>Squre root sum</title>
		<meta charset = 'UTF-8' />
		<style>
			table.table {
				border: 1px solid black;
			}
			
			tr, th, td {
				border: 1px solid black;
			}
		</style>
	</head>
	<body>
		<?php
		$sum = 0; 
		$table = "<table class=\"table\"><thead><tr><th>Number</th><th>Square</th></tr></thead><tbody>";
		for ($i=0; $i <= 100 ; $i++) {
			if( $i % 2 === 0){
				$square = round(sqrt($i),2);
				$sum += $square;
				$table .= "<tr><td>$i</td><td>$square</td></tr>";
			}
		}
				
		$table .= "<tr><td><strong>Total</strong></td><td>$sum</td></tr></tbody></table>";
		echo $table;	 
		?>
	</body>
</html>