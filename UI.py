from functools import partial
import os, time, datetime, tkinter

mydate = datetime.datetime.now()

#Function to get the branches of the current month
def getMonthBranches():
    mydate = datetime.datetime.now()
    if os.path.exists("Z://{0}//{1}".format(mydate.year,mydate.strftime("%B"))) == True:
        branches = os.listdir("Z://{0}//{1}".format(mydate.year,mydate.strftime("%B")))
    else:
        first = mydate.replace(day=1)
        lastMonth = first - datetime.timedelta(days=1)
        branches = os.listdir("Z://{0}//{1}".format(lastMonth.year,lastMonth.strftime("%B")))
    for folder in branches:
        if folder[0] == ".":
            branches.remove(folder)
    return(branches)

class App():
    def __init__(self):
        branchesVar = []
        self.root = tkinter.Tk()
        self.root.configure(background = "white")
        self.root.title("Silhouette Build Notifier")
        self.root.wm_iconbitmap('silhouette_logo.ico')

        branches = getMonthBranches()
        for folder in branches:
            if folder[0] == ".":
                branches.remove(folder)

        lTitle = tkinter.Label(self.root, text = "Silhouette R&T Build Notifier", background ="white", font=("Segoe UI", 14))
        ldate = tkinter.Label(self.root, text = "{0} - {1}".format(mydate.strftime("%B"), mydate.year), background ="white", font=("Segoe UI", 12))
        bQuit = tkinter.Button(self.root, text = 'Minimise', background = "#4FB2CE", foreground = "white", activebackground = "#339AB7", activeforeground = "white", highlightthickness = 0, bd = 0, command=self.quit, font=("Segoe UI", 12))
       
        lTitle.grid(pady = 5, padx = 10, columnspan = 3)
        ldate.grid(columnspan = 3, pady = (0,15))

        for count, branch in enumerate(branches):
            branchesVar.append(tkinter.IntVar())
            if os.path.exists("watchlist.txt") == True:
                with open("watchlist.txt", "r") as watchlist:
                    for line in watchlist:
                        lineStripped = line.rstrip("\n")
                        if lineStripped == branch:
                            branchesVar[count].set(1)
            l = tkinter.Checkbutton(self.root, text=branch, command = partial(self.printSelf,branchesVar, branches), variable=branchesVar[count], background = "white", font=("Segoe UI", 10))
            l.grid(pady = 1, padx = 10, column = 1, columnspan = 2, row = count+3, sticky = "W")
            counter = count
        bQuit.grid(pady = 10, padx = 10, sticky="SE", row = counter + 4, column = 2)
        self.root.mainloop()

    def printSelf(self, branchesVar, branches):
        file = open("watchlist.txt", "w+")
        for count,i in enumerate(branchesVar):
            if branchesVar[count].get() == 1:
                file.write(branches[count] + "\n")
        file.close
        return()

    def quit(self):
        self.root.iconify()
        return()