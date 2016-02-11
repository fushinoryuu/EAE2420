# values = [14, 20, 19, 3, 2, -1, 14, 15, 3]
#
# def indexOf(numbers, value):
#     index = 0
#     for item in numbers:
#         if item == value:
#             return index
#         index += 1
#
# assert(indexOf(values, 3) == 3)
#

class Node:
    def __init__(self, data, next = None):
        self.data = None
        self.next = None

        # def get_data(self):
        #     return self.data
        #
        # def get_next(self):
        #     return self.next
        #
        # def set_next(self, new_next):
        #     self.next = new_next

class LinkedList:
    def __init__(self):
        self.head = None

    def append(self, value):
        newNode = Node(value)
        if self.head != None:
            runner = self.head
            while runner.next != None:
                runner = runner.next
            runner.next = newNode
        else:
            self.head = newNode

myList = LinkedList()
myList.append(8)


# node1 = Node()
# node1.data = 5
# node2 = Node()
# node2.data = 1
# node3 = Node ()
# node3.data = 8
#
# node1.next = node2
# node2.next = node3
#
# runner = node1
# while runner != None:
#     print(runner.data)
#     runner = runner.next