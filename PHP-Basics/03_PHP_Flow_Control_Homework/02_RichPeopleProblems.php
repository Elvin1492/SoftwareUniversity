<!DOCTYPE html>
<html>
	<head>
		<title>Rich People's Problem</title>
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
				Enter Cars: <input type="text" name="cars" placeholder="enter cars" required/>
				            <input type="submit" name="submit" value="Show results"/>
			</form><br/>
		
		<?php
		if(isset($_POST['cars'])){
			$table = "<table class=\"table\"><thead><tr><th>Car</th><th>Colour</th><th>Couunt</th></tr></thead><tbody>";
			$cars = explode(", ",$_POST['cars']);
			$colors = array('red','green','blue','white','black','grey','orange','yellow');
			for ($i=0; $i < count($cars) ; $i++) {
				$table .= "<tr><td>".htmlentities($cars[$i])."</td><td>".$colors[rand(0,7)]."</td><td>".rand(1,5)."</td></tr>"; 
				
			}
			$table .= "</tbody></table>";
			echo $table;		
		}
		?>
	</body
</html>