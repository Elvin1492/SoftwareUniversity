<?php

function information_table($name, $pnone_number, $age, $adress){
	return     "<table style = \"border: 1px solid black;\">		
		<tr style = \"border: 1px solid black;\">
			<td >Name</td>
			<td>$name</td>
		</tr>
		<tr>
			<td>Phone number</td>
			<td>$pnone_number</td>
		</tr>
		<tr>
			<td>Age</td>
			<td>$age</td>
		</tr>
		<tr>
			<td>Address</td>
			<td>$adress</td>
		</tr>   	
    </table>";
}


echo information_table('Gosho', '0882-321-423', 24, 'Hadji Dimitar');

?>
