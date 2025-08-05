import { sveltePreprocess } from 'svelte-preprocess';
import { defineConfig } from 'vite';
import { svelte } from '@sveltejs/vite-plugin-svelte';

export default defineConfig({
  plugins: [svelte({
    preprocess: sveltePreprocess(),
  })],
  server: {
    port: 3000,
    open: true,
  },
  build: {
    outDir: 'dist',
  },
  resolve: {
    alias: {
      $components: '/src/lib/components',
    },
  },
});