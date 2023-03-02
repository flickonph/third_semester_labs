# Example of method
def print_func(param):
    str_param = str(param)  # Parsing to string format
    print(str_param)  # Calling print() func


def main():
    print("Type name or leave blank to say hello to whole world, 'exit' to exit")  # Welcome text
    str_text = input()  # Reading lines from console

    if str_text == "":
        str_text = "Hello, World!"  # Default value
        print_func(str_text)  # Calling example method
    elif str_text == "exit":
        __ = None  # Does nothing to end script
    else:
        local_tuple = ("Hello, ", str_text, "!")
        str_text = "".join(local_tuple)
        print_func(str_text)  # Calling example method
