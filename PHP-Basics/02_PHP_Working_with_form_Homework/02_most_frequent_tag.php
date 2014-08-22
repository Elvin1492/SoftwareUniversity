<!DOCTYPE html>
<html>
	<head>
		<title>Most frequent tag</title>
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
		  $tags_frequency = array_count_values($tags_array);
		  arsort($tags_frequency);
		  reset($tags_frequency);
		  $first_tag = key($tags_frequency);
		  
		  foreach ($tags_frequency as $tag => $count) {
			  echo htmlspecialchars($tag).": $count times"."<br/>";
		  }
		  echo "<br/>";	  
		  echo   "Most frequent tag is: $first_tag";
		  
		}		
		?>		
	</body>
</html>
