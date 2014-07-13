
bin = bin/Debug
#bin = bin/Release
executable = beat-planner.exe
srcs = src/BeatPlanner.cs src/Metronome.cs src/Utils.cs src/SoundPlayer.cs

output = $(bin)/$(executable)

.PHONY: test

test: $(output)
	mono $<

clean:
	@rm -f -r bin

build: $(output)

$(output): $(srcs)
	xbuild beat-planner.sln


#bin = bin/
#lib = lib/
#output = $(bin)BeatPlanner.exe
#sources = src/BeatPlanner.cs src/Metronome.cs src/Utils.cs
#
#.PHONY: test
#
#build: $(output)
#	@echo "$(output) built successfully"
#
#test: $(output)
#	@mono $<
#
#clean:
#	@rm -f -r bin
#
#$(output): $(sources)
#	mkdir -p bin
#	mcs -debug+ -out:$(output) $(sources)
#
#
#
#
#	
#