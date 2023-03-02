import os

import lab_1.script as lab0
import lab_2.first1 as lab1_1
import lab_2.second1 as lab1_2
import lab_2.third1 as lab1_3

num = input()
int_number = int(num)
print("Starting")
if int_number != "":
    if int_number == 0:
        lab0.main()
    elif int_number == 1:
        lab1_1.first_task()
        lab1_2.second_task()
        lab1_3.third_task()
        lab1_3.fourth_task()
    else:
        print("Not provided")
else:
    print("Not provided")
