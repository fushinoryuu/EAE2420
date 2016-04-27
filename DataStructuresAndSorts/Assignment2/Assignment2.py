import sys
import random
import math


def swap_numbers(numbers, index1, index2):
    """This function takes in a list and two indexes to switch them in the list."""
    temp = numbers[index1]
    numbers[index1] = numbers[index2]
    numbers[index2] = temp


def bubble_sort(numbers):
    """This function will perform a bubble sort on the given list."""
    for start in range(0, len(numbers) - 1):
        current_item = 0
        for next_item in range(1, len(numbers)):
            if numbers[current_item] > numbers[next_item]:
                swap_numbers(numbers, current_item, next_item)
            current_item += 1


def any(numbers, condition):
    """This function will return True if any number in the list meets
    the lambda condition when the function is called."""
    for i in numbers:
        if condition(i):
            return True


def all(numbers, condition):
    """This function will only return True if all the elements in the list meet
    the lamda condition when the function is called."""
    for i in numbers:
        if not condition(i):
            return False
    return True


def count(numbers, condition):
    """This function returns how many elements in the list satisfy the condition."""
    total = 0
    for i in numbers:
        if condition(i):
            total += 1
    return total


def genOrdered(elements):
    """This function generates a sequence of random but ordered elements."""
    x = 0
    for i in range(elements):
        x += random.randint(x, x + 7)
        yield x


def binarySearch(numbers, element):
    """This function will perform a Binary search."""
    low = 0
    high = len(numbers) - 1
    while (low <= high):
        mid = math.floor((low + high) / 2)
        if numbers[mid] > element:
            high = mid - 1
        elif numbers[mid] < element:
            low = mid + 1
        else:
            return mid


def where(numbers, condition):
    """This function returns a sequence of item that satisfies the condition."""
    new_list = []
    for i in numbers:
        if condition(i):
            new_list.append(i)
    return new_list


def select(numbers, transform):
    """This function converts each item in the sequence using transform."""
    new_list = []
    for i in numbers:
        new_list.append(transform(i))
    return new_list


def main():
    """This is the main function that will call all the functions in this file."""
    bubble_list = [8, 4, 2, 7, 3, 1]
    some_list = [2, 4, 6, 1]

    print("Before bubble sort: ", bubble_list)
    bubble_sort(bubble_list)
    print("After bubble sort: ", bubble_list, '\n')

    print("This is the list that will be use for the lambda functions:", some_list)
    print("Are ANY of the numbers on the list greater than 0?", any(some_list, lambda x: x >= 0))
    print("Are ALL the numbers on the list divisible by 2?", all(some_list, lambda x: x % 2 == 0))
    print("How many numbers on the list are divisible by 2?", count(some_list, lambda x: x % 2 == 0), '\n')

    # Create the generator object
    generator = genOrdered(5)
    print("A list of random but ordered numbers:")
    for i in generator:
        print(i)
    print("")

    print("Binary list:", bubble_list)
    print("The index of 8 is:", binarySearch(bubble_list, 8), '\n')

    print("List used for the WHERE and SELECT functions:", bubble_list)
    print("List of numbers divisible by 4:", where(bubble_list, lambda x: x % 4 == 0))
    print("List of the numbers multiplied by 2:", select(bubble_list, lambda x: 2*x))

if __name__ == "__main__":
    main()
    sys.exit()