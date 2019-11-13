import os,time, datetime, multiprocessing, tkinter
from win10toast_persist import ToastNotifier

mydate = datetime.datetime.now()
def watcherV2():
    toaster = ToastNotifier()
    #Checks to see if the watchlist has been created, if not it waits 10 seconds before checking again
    while True:
        if not os.path.exists("watchlist.txt"):
            time.sleep(10)
        else:
            #Once it finds the watchlist file, create a list of all file contents in the branch folders inside it (PC Only)
            with open("watchlist.txt", "r") as watchlist:
                for line in watchlist:
                    line = line.rstrip("\n")
                    branchSet1 = open("{}.txt".format(line), "w+")
                    branchContents = bListDir(line)
                    for file in branchContents:
                        branchSet1.write(file + "\n")
                    branchSet1.close()
            #Wait 5 minutes before checking
            print("15")
            time.sleep(15)
            with open("watchlist.txt", "r") as watchlist:
                #Goes through each line for the branch number
                for line in watchlist:
                    #Clears the sets for each branch
                    set1 = []
                    set2 = []
                    line = line.rstrip("\n")
                    #Opens the initally created list of the branch and adds it to a list
                    branchFile = open("{}.txt".format(line), "r")
                    for file in branchFile:
                        set1.append(file)
                    #Lists the directory at present time and converts it to a list
                    branchSet2 = bListDir(line)
                    for file in branchSet2:
                        set2.append(file)

                    #Checks the new list to the old list to see if it's a new item
                    for item in set2:
                        isNew = True
                        for oldItem in set1:
                            oldItem = oldItem.rstrip("\n")
                            if item == oldItem:
                                isNew = False
                        #If gone through the loop and hasn't been set to false, must be new so notify
                        if isNew ==True:
                            toaster.show_toast("Silhouette Build Detection","{0} is now avaliable in {1}".format(item,line), icon_path="silhouette_logo.ico", threaded=True, duration = None)

    return()

#Adds or removes the txt files based on whats checked in the UI
def branchFileUpdater(branch, branchVar):
    for count, item in enumerate(branch):
        if branchVar[count].get() == 1:
            if os.path.exists("{}.txt".format(branch[count])) !=True:
                with open("{}.txt".format(branch[count]), "w+") as branchFile:
                    branchFiles = bListDir(branch[count])
                    for file in branchFiles:
                        branchFile.write(file + "\n")
        elif os.path.exists("{}.txt".format(branch[count])) == True and branchVar[count].get() == 0:
            os.remove("{}.txt".format(branch[count]))
    return()

def bListDir(branchNo):
    branchContents = os.listdir("//srtserver-01/build_folder//{0}//{1}//{2}//WIN".format(mydate.year,mydate.strftime("%B"),branchNo))
    return(branchContents)