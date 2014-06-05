desc 'default'
task default: [:build, :test]

desc 'build'
task :build do
    sh 'msbuild'
end

desc 'rebuild'
task :rebuild do
    sh 'msbuild /t:clean;rebuild'
end

desc 'test'
task :test do
    sh 'packages/xunit.runners.1.9.2/tools/xunit.console.clr4.exe bin/debug/Cards.Extensions.Tfs.Tests.dll'
end
