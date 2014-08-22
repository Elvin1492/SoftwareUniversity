<!DOCTYPE html>
<html>
	<head>
		<title>calculate interest</title>
		<meta charset='UTF-8' />
	</head>
	<body>
		<form method="post" action="<?php $_PHP_SELF ?>">
			<div>
				<label for="amount">Enter amount:</label>
				<input type="number" step="10" min="100" max="100000" name="amount" id="amount" />
			</div>
			<div>
				<input type="radio" name="currency" value="USD"/>USD
				<input type="radio" name="currency" value="EUR"/>EUR
				<input type="radio" name="currency" value="BGN"/>BGN
			</div>
			<div>
				<label for="interest">Compound interest amount:</label>
				<input type="number" step="0.1" min="0.1" max="30"  name="interest" id="interest" />
			</div>
			<div>
				<select name="period">
					<option value="0.25">3 months</option>
					<option value="0.5">6 months</option>
					<option value="1">1 year</option>
					<option value="2">2 years</option>
					<option value="5">5 years</option>
					<option value="10">10 years</option>					
				</select>
				<input type="submit" name="submit" value="submit"/>	
			</div>
	
		</form>
		 
		<?php	
		if(isset($_POST['submit']))
		{
		  $amount = $_POST['amount'];
		  $currency = $_POST['currency'];
		  $interest = $_POST['interest'] / 100;
		  $months =  $_POST['period'] * 12;
		  
		  $total = 0;
		  for ($i=0; $i < $months ; $i++) {
		  	 $total = $amount * (1 + $interest / 12);
		  	 $amount = $total;
		  }
		  
		  $total = round($total,2);
		  echo "$total  $currency ";
		}		
		?>		
	</body>
</html>
