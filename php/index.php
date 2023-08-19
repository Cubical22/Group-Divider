<?php

$goal = 30;
$dividers = [1,2,3];
$length = sizeof($dividers);

$multipliers = [];

// adding zeros to the multipliers list
for ($i = 0; $i < $length; $i++) {
    $multipliers[$i] = 0;
}

function getOverallSum($multipliers, $dividers) {
    $overallSum = 0;
    for ($i = 0; $i < sizeof($multipliers); $i++) {
        $overallSum+=$multipliers[$i] * $dividers[$i];
    }

    return $overallSum;
}

function setFailedAndBelowToZero($failedStateCount, $multipliers) {
    for ($i = $failedStateCount; $i >= 0; $i--) {
        $multipliers[$i] = 0;
    }
    return $multipliers;
}

function logSuccessCase($multipliers, $dividers) {
    $outString = "success)";
    for ($i = 0; $i < sizeof($dividers); $i++) {
        $outString = $outString." ".$dividers[$i].": ".$multipliers[$i]." |";
    }

    print $outString."\n";
}

$failedStateCount = 0;
$successCount = 0;

while (true) {
    if ($failedStateCount >= $length) {
        break;
    }

    $multipliers[$failedStateCount]++;
    $overallSum = getOverallSum($multipliers, $dividers);

    if ($overallSum == $goal) {
        // success state
        $successCount++;
        logSuccessCase($multipliers, $dividers);
    } else if ($overallSum > $goal) {
        // fail state
        $multipliers = setFailedAndBelowToZero($failedStateCount, $multipliers);
        $failedStateCount++;
        continue;
    }
    $failedStateCount = 0;
}

echo "the number of success cases is [". $successCount. "]";
