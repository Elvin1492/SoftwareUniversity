<!DOCTYPE html>
<html>
	<head>
		<title>Sidebar builder</title>
		<meta charset ='UTF-8' />
		<style>
			input[type='text'] {
				width: 250px;
			}
			div.sidebar {
				border: 2px solid black;
				border-radius: 10px;
				background-color: #ACC4E6;
				width: auto;
				padding: 10px;
				display: inline-block;
				margin-right: 20px;
			}

			ul li {
				text-decoration:underline;
				list-style-type:circle;
			}
		</style>
	</head>
	<body>
		<form method="post" action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>">
			<div>
			 <label for="categories">Categories:</label>
		     <input type="text" name="categories" id="categories" />
		    </div>
		    <div>
			 <label for="tags">Tags:</label>
		     <input type="text" name="tags" id="tags" />
		    </div>
		    <div>
			 <label for="months">Months:</label>
		     <input type="text" name="months" id="months" />
		    </div>
			<input type="submit" name="submit" value="Generate" />
		</form><br />
	<?php
	 if( (isset($_POST['categories'])) && (!empty($_POST['categories'])) && (isset($_POST['tags'])) && (!empty($_POST['tags'])) &&
	 (isset($_POST['months'])) && (!empty($_POST['months'])) && (isset($_POST['submit'])) ){	 			
	   $ctgr = $_POST['categories'];
	   $tgs = $_POST['tags'];
	   $mnts = $_POST['months'];
	   
	   $pattern = '/[,\s+]+/';
	   $categoreis = preg_split($pattern, $ctgr, -1, PREG_SPLIT_NO_EMPTY);
	   $tags = preg_split($pattern, $tgs, -1, PREG_SPLIT_NO_EMPTY);
	   $months = preg_split($pattern, $mnts, -1, PREG_SPLIT_NO_EMPTY);
	   
	   //create categories sidebar
	   $categories_sidebar = "<div class = \"sidebar\"> <h1>Categories</h1><hr><ul>";
	   foreach ($categoreis as $category) {
		   $categories_sidebar .= "<li>$category</li>";
	   };
	   $categories_sidebar .= "</ul></div>";

	   //create tags sidebar
	   $tags_sidebar = "<div class = \"sidebar\"> <h1>Tags</h1><hr><ul>";
	   foreach ($tags as $tag) {
		   $tags_sidebar .= "<li>$tag</li>";
	   };
	   $tags_sidebar .= "</ul></div>";
	   
	   //create months sidebar
	   $months_sidebar = "<div class = \"sidebar\"> <h1>Months</h1><hr><ul>";
	   foreach ($months as $month) {
		   $months_sidebar .= "<li>$month</li>";
	   };
	   $months_sidebar .= "</ul></div>";
	   //print sidebars
	   echo $categories_sidebar;
	   echo $tags_sidebar;
	   echo $months_sidebar;
	   
	
	 }
	?>
</body>
</html>



