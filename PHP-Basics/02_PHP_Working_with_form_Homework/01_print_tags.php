<!DOCTYPE html>
<html>
	<head>
		<title>Print tags</title>
		<meta charset='UTF-8' />
	</head>
	<body>
		<form method="post" action="<?php $_PHP_SELF ?>">
			<label for="tags">Enter tags:</label><br/>
			<input type="text" name="tags" id="tags" />
			<input type="submit" />			
		</form><br/>	   
		<?php	
		if(isset($_POST['tags']))
		{
		  $tags_array = explode(", ",$_POST['tags']); 
		  foreach ($tags_array as $key => $value) {
			  echo "$key:". htmlspecialchars($value)."<br>";
		  }	
		}		
		?>		
	</body>
</html>
