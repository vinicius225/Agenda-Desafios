import { defineConfig, loadEnv } from "vite";
import vue from "@vitejs/plugin-vue";
 
// https://vitejs.dev/config/
 
export default ({ mode }) => {
  const env = loadEnv(mode, process.cwd(), "");
  return defineConfig({
    define: {
      "process.env": env,
    },
    plugins: [
      vue({
        template: {
          compilerOptions: {
            isCustomElement: (tag) => ['row'].includes(tag),
          }
        }
      })
    ],
    server: {
      host: true,
      port: 8080,
    },
    resolve: {
      alias: {
        // Você pode usar diretamente o caminho relativo para o diretório 'src'
        "@": "/src",
      },
    },
  });
};
