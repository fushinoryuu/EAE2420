# Christian Munoz
# Student Id: u0556573
# Assignment 3

import random
import sys


class Node:
    """This class represent a node that will be used in a linked list."""
    def __init__(self, data, next=None, previous=None):
        self.data = data
        self.next = next
        self.previous = previous


class LinkedList:
    """This class represents a linked list that will use the Node class above."""
    def __init__(self):
        self.head = None
        self.tail = None
        self.length = 0
        self.current = None

    def insertAfter(self, node, value):
        """Inserts value into a new node after the given node."""
        if node is self.tail:
            new_node = Node(value, None, node)
            self.tail = new_node
        else:
            new_node = Node(value, node.next, node)
            node.next.previous = new_node
        node.next = new_node
        self.length += 1

    def insertBefore(self, node, value):
        """Inserts value into a new node before the given node."""
        if node is self.head:
            new_node = Node(value, node, None)
            self.head = new_node
        else:
            new_node = Node(value, node, node.previous)
            node.previous.next = new_node
        node.previous = new_node
        self.length += 1

    def addFirst(self, value):
        """Adds the given value as the first value in the list."""
        new_node = Node(value, self.head, None)
        if self.head is not None:
            self.head = new_node
            self.head.next.previous = new_node
        else:
            self.head = new_node
            self.tail = new_node
        self.length += 1

    def addLast(self, value):
        """Adds the given value as the last value in the list."""
        new_node = Node(value, None, self.tail)
        self.tail = new_node
        if self.head is None:
            self.head = new_node
        else:
            self.tail.previous.next = new_node
        self.length += 1

    def find(self, value):
        """Returns the node that contains the given value."""
        if self.head is not None:
            runner = self.head
            while runner is not None:
                if runner.data == value:
                    return runner
                runner = runner.next
        return None

    def remove(self, node):
        """Removes the given node from the list."""
        if node is self.head:
            self.head = node.next
            node.next.previous = None
            node.next = None
        elif node is self.tail:
            self.tail = node.previous
            node.previous.next = None
            node.previous = None
        else:
            node.previous.next = node.next
            node.next.previous = node.previous
        self.length -= 1

    def first(self):
        """Returns the first node."""
        return self.head

    def last(self):
        """Returns the last node."""
        return self.tail

    def count(self):
        """Returns the number of items in the list."""
        return self.length

    def __iter__(self):
        """Allows the user to iterate over the values (not the nodes)."""
        self.current = self.head
        return self

    def next(self):
        # self.current = self.head
        if self.current is not None:
            temp = self.current
            self.current = self.current.next
            return temp.data
        else:
            raise StopIteration()


def swap_numbers(numbers, index1, index2):
    """This function takes in a list and two indexes to switch them in the list."""
    temp = numbers[index1]
    numbers[index1] = numbers[index2]
    numbers[index2] = temp


def partition(numbers, low, high):
    """This function sets a pivot in the list and compares the values."""
    pivot = numbers[low]
    wall = low
    for i in range(low + 1, high):
        if numbers[i] < pivot:
            wall += 1
            swap_numbers(numbers, i, wall)
    swap_numbers(numbers, low, wall)
    return wall


def quick_sort(numbers, low, high):
    """This function will perform a quick sort on the list provided."""
    if low < high:
        pivot_location = partition(numbers, low, high)
        quick_sort(numbers, low, pivot_location)
        quick_sort(numbers, pivot_location + 1, high)


def main():
    """This is the main function that calls all the other functions."""

    # Quicksort section
    sorted_list = [1, 2, 3, 4, 5]
    reversed_list = [10, 9, 8, 7, 6]
    unsorted_list = [11, 15, 19, 12, 13]
    oneitem_list = [20]
    twoitem_list = [22, 21]
    nineitem_list = random.sample(range(1, 50), 9)
    thirteenitem_list = random.sample(range(51, 100), 13)
    twentyoneitem_list = random.sample(range(1, 99), 21)

    print("Lists that will be used with Quicksort:\n")
    print("Sorted List:", sorted_list)
    print("Reversed List:", reversed_list)
    print("Unsorted List:", unsorted_list)
    print("One Item List:", oneitem_list)
    print("Two Item List:", twoitem_list)
    print("Nine Item List:", nineitem_list)
    print("Thirteen Item List:", thirteenitem_list)
    print("Twenty One Item List:", twentyoneitem_list, '\n')

    # Sorting a sorted list
    quick_sort(sorted_list, 0, len(sorted_list))
    assert sorted_list == [1, 2, 3, 4, 5]

    # Sorting a list that is in reverse order
    quick_sort(reversed_list, 0, len(reversed_list))
    assert reversed_list == [6, 7, 8, 9, 10]

    # Sorting an unsorted list
    quick_sort(unsorted_list, 0, len(unsorted_list))
    assert unsorted_list == [11, 12, 13, 15, 19]

    # Sorting a one item list
    quick_sort(oneitem_list, 0, len(oneitem_list))
    assert oneitem_list == [20]

    # Sorting a two item list
    quick_sort(twoitem_list, 0, len(twoitem_list))
    assert twoitem_list == [21, 22]

    # Sorting a random 9 item list
    quick_sort(nineitem_list, 0, len(nineitem_list))
    for item in range(0, len(nineitem_list)):
        if item < len(nineitem_list) - 1:
            assert nineitem_list[item] < nineitem_list[item + 1]

    # Sorting a random 13 item list
    quick_sort(thirteenitem_list, 0, len(thirteenitem_list))
    for item in range(0, len(thirteenitem_list)):
        if item < len(thirteenitem_list) - 1:
            assert thirteenitem_list[item] < thirteenitem_list[item + 1]

    # Sorting a random 21 item list
    quick_sort(twentyoneitem_list, 0, len(twentyoneitem_list))
    for item in range(0, len(twentyoneitem_list)):
        if item < len(twentyoneitem_list) - 1:
            assert twentyoneitem_list[item] < twentyoneitem_list[item + 1]

    print("Lists after Quicksort:\n")
    print("Sorted List:", sorted_list)
    print("Reversed List:", reversed_list)
    print("Unsorted List:", unsorted_list)
    print("One Item List:", oneitem_list)
    print("Two Item List:", twoitem_list)
    print("Nine Item List:", nineitem_list)
    print("Thirteen Item List:", thirteenitem_list)
    print("Twenty One Item List:", twentyoneitem_list, '\n')

    # Linked List section
    linked_list = LinkedList()
    test_list = [1, 3, 5, 7, 9]

    for i in test_list:
        linked_list.addLast(i)

    # Initial linked list
    print("This is the starting Linked List:\n")
    default_runner = linked_list.head
    while default_runner is not None:
        print("Value of Node:", default_runner.data, "Address:", default_runner)
        default_runner = default_runner.next
    print("Length:", linked_list.count(), "Head:", linked_list.first().data, "Tail:", linked_list.last().data)

    # Deleting a couple of nodes
    print("\nDeleting 1 and 9 from the list. New list:\n")
    linked_list.remove(linked_list.find(1))
    linked_list.remove(linked_list.find(9))
    delete_runner = linked_list.head
    while delete_runner is not None:
        print("Value of Node:", delete_runner.data, "Address:", delete_runner)
        delete_runner = delete_runner.next
    print("Length:", linked_list.count(), "Head:", linked_list.first().data, "Tail:", linked_list.last().data)

    # Inserting a couple of node
    print("\nInserting 6 at the beginning and 4 at the end. New list:\n")
    linked_list.addFirst(6)
    linked_list.addLast(4)
    add_runner = linked_list.head
    while add_runner is not None:
        print("Value of Node:", add_runner.data, "Address:", add_runner)
        add_runner = add_runner.next
    print("Length:", linked_list.count(), "Head:", linked_list.first().data, "Tail:", linked_list.last().data)

    # Inserting a couple more nodes
    print("\nInserting 2 before 3, inserting 8 after 7. New list: \n")
    linked_list.insertBefore(linked_list.find(3), 2)
    linked_list.insertAfter(linked_list.find(7), 8)
    mod_runner = linked_list.head
    while mod_runner is not None:
        print("Value of Node:", mod_runner.data, "Address:", mod_runner)
        mod_runner = mod_runner.next
    print("Length:", linked_list.count(), "Head:", linked_list.first().data, "Tail:", linked_list.last().data)

    # Iterate through the list
    print("\nIterating through the list:\n")
    iter = linked_list.__iter__()
    for i in range(linked_list.length):
        print("Next value:", iter.next())

if __name__ == "__main__":
    main()
    sys.exit()