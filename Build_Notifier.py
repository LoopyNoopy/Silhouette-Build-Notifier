import multiprocessing, os, time, watcher, UI
  
def print_cube(num): 
    """ 
    function to print cube of given num 
    """
    print("Cube: {}".format(num * num * num)) 
  
def print_square(num): 
    """ 
    function to print square of given num 
    """
    print("Square: {}".format(num * num)) 

  
if __name__ == "__main__": 
    # creating processes 
    multiprocessing.Process(target=UI.App).start()
    multiprocessing.Process(target=watcher.watcherV2).start()
  
    # both processes finished 
    print("Done!") 
