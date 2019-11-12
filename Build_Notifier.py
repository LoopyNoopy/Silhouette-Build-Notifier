import multiprocessing, os, time, watcher, UI
  
if __name__ == "__main__": 
    # creating processes 
    multiprocessing.Process(target=UI.App).start()
    multiprocessing.Process(target=watcher.watcherV2).start()
  
    # both processes finished 
    print("Done!") 
