# Christian Munoz
# Student Id: u0556573
# Assignment 1

import sys


def swap_numbers(numbers, index1, index2):
    """This function takes in a list and two indexes to switch them in the list."""
    temp = numbers[index1]
    numbers[index1] = numbers[index2]
    numbers[index2] = temp


def find_smallest(numbers):
    """This function finds the smallest number in a list."""
    small = numbers[0]
    for item in numbers:
        if item < small:
            small = item
    return small


def sum_items(numbers):
    """This functions finds the sum of all numbers in a given list."""
    total = 0
    for item in numbers:
        total += item
    return total


def find_index(numbers, element):
    """This function will find the index for the element in the given list."""
    index = 0
    for item in numbers:
        if element != item:
            index += 1
        elif element == item:
            return index


def selection_sort(numbers):
    """This function will perform a selection sort on the given list."""
    for index in range(0, len(numbers) - 1):
        min_value = numbers[index]
        for j in range(index + 1, len(numbers)):
            if numbers[j] < min_value:
                min_value = numbers[j]
        if min_value != numbers[index]:
            swap_numbers(numbers, find_index(numbers, min_value), index)
    assert numbers == [0, 2, 3, 7, 8, 9], "SELECTION SORT: The list was not sorted correctly."


def insertion_sort(numbers):
    """This function will perform a insertion sort on the given list."""
    for index in range(0, len(numbers) - 1):
        current = numbers[index]
        j = index
        while j > 0 and numbers[j - 1] > current:
            numbers[j] = numbers[j - 1]
            j -= 1
        numbers[j] = current
    assert numbers == [1, 2, 5, 6, 7, 9], "INSERTION SORT: The list was not sorted correctly."


def main():
    """This is the function that will call all the other functions in the file."""
    swap_list = [9, 5, 3, 2, 7, 4]
    selection_list = [7, 2, 8, 9, 0, 3]
    insertion_list = [5, 2, 6, 7, 1, 9]

    print("Before swap: ", swap_list)
    swap_numbers(swap_list, 3, 5)
    print("After swap: ", swap_list, '\n')

    print("The smallest number on the list is: ", find_smallest(swap_list), '\n')

    print("The sum of the list is: ", sum_items(swap_list), '\n')

    print("The index of 5 is: ", find_index(swap_list, 5), '\n')

    print("Before selection sort: ", selection_list)
    selection_sort(selection_list)
    print("After selection sort: ", selection_list, '\n')

    print("Before insertion sort: ", insertion_list)
    insertion_sort(insertion_list)
    print("After insertion sort: ", insertion_list)

if __name__ == "__main__":
    main()
    sys.exit()