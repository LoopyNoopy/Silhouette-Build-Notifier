import multiprocessing, os, time, watcher, UI
  
if __name__ == "__main__": 
    # creating processes 
    multiprocessing.Process(target=UI.App).start()
    watcherProcess = multiprocessing.Process(target=watcher.watcherV2)
    while True:
        watcherProcess.start()
        watcherProcess.join()
  
    # both processes finished 
    print("Done!") 
